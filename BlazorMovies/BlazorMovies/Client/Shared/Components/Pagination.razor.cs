using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class Pagination
    {
        private List<LinkModel> links;

        [Parameter]
        public int CurrentPage { get; set; } = 1;

        [Parameter]
        public int TotalAmountOfPages { get; set; }

        [Parameter]
        public int Radius { get; set; } = 3;

        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        private void LoadPages()
        {
            links = new List<LinkModel>();
            var isPreviousPageLinkEnabled = CurrentPage != 1;
            var previousPage = CurrentPage - 1;
            links.Add(new LinkModel(previousPage, isPreviousPageLinkEnabled, "Previous"));

            for (int i = 1; i <= TotalAmountOfPages; i++)
            {
                if (i >= CurrentPage - Radius && i <= CurrentPage + Radius)
                {
                    links.Add(new LinkModel(i) { Active = CurrentPage == i });
                }
            }

            var isNextPageLinkEnabled = CurrentPage != TotalAmountOfPages;
            var nextPage = CurrentPage + 1;
            links.Add(new LinkModel(nextPage, isNextPageLinkEnabled, "Next"));
        }

        protected override void OnParametersSet()
        {
            LoadPages();
            base.OnParametersSet();
        }

        private async Task SelectedPageInternal(LinkModel link)
        {
            if (link.Page == CurrentPage || !link.Enabled)
            {
                return;
            }

            CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }


        #region Private Model

        private class LinkModel
        {
            public LinkModel(int page)
                : this(page, true)
            {
            }

            public LinkModel(int page, bool enabled)
                : this(page, enabled, page.ToString())
            {
            }

            public LinkModel(int page, bool enabled, string text)
            {
                Page = page;
                Enabled = enabled;
                Text = text;
            }

            public string Text { get; set; }

            public int Page { get; set; }

            public bool Enabled { get; set; } = true;

            public bool Active { get; set; } = false;
        }

        #endregion
    }
}

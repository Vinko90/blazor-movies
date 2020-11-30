using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BlazorMovies.Components.Shared
{
    public partial class CustomTypeahead<TItem>
    {
        #region Internal Variables

        private bool isSearching = false;
        private bool isShowingSuggestions = false;
        private string searchText = string.Empty;
        private Timer debounceTimer;
        private bool isMouseInSuggestion = false;

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            debounceTimer = new Timer
            {
                Interval = Debounce,
                AutoReset = false
            };
            debounceTimer.Elapsed += Search;
        }

        protected async void Search(object source, ElapsedEventArgs e)
        {
            isSearching = true;
            isShowingSuggestions = false;
            await InvokeAsync(StateHasChanged);

            Suggestions = (await SearchMethod.Invoke(searchText)).ToArray();
            isSearching = false;
            isShowingSuggestions = true;
            await InvokeAsync(StateHasChanged);
        }

        private string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;

                if (value.Length == 0)
                {
                    isShowingSuggestions = false;
                    debounceTimer.Stop();
                    Suggestions = new TItem[0];
                }
                else if (value.Length >= MinimumLenght)
                {
                    debounceTimer.Stop();
                    debounceTimer.Start();
                }
            }
        }

        private void ShowSuggestions()
        {
            if (Suggestions.Any())
            {
                isShowingSuggestions = true;
            }
        }

        private void OnFocusOut()
        {
            if (!isMouseInSuggestion)
            {
                isShowingSuggestions = false;
            }
        }

        private bool ShouldShowSuggestions()
        {
            return isShowingSuggestions && Suggestions.Any();
        }

        private async Task SelectSuggestion(TItem item)
        {
            SearchText = "";
            await ValueChanged.InvokeAsync(item);
        }

        private bool ShowNotFound()
        {
            return !Suggestions.Any() && isShowingSuggestions;
        }

        private void OnMouseOverSuggestion()
        {
            isMouseInSuggestion = true;
        }

        private void OnMouseOutSuggestion()
        {
            isMouseInSuggestion = false;
        }

        #endregion

        #region Parameters

        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public int MinimumLenght { get; set; } = 3;

        [Parameter]
        public int Debounce { get; set; } = 300;

        [Parameter]
        public Func<string, Task<IEnumerable<TItem>>> SearchMethod { get; set; }

        [Parameter]
        public RenderFragment<TItem> ResultTemplate { get; set; }

        [Parameter]
        public RenderFragment NotFoundTemplate { get; set; }

        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        protected TItem[] Suggestions { get; set; } = new TItem[0];

        #endregion
    }
}
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Components.Shared
{
    public partial class Confirmation
    {
        private bool displayConfirmation = false;

        public void Show() => displayConfirmation = true;

        public void Hide() => displayConfirmation = false;

        [Parameter]
        public string Title { get; set; } = "Confirm";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback OnConfirm { get; set; }

        [Parameter]
        public EventCallback OnCancel { get; set; }
    }
}

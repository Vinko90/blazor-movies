using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class Confirmation
    {
        [Parameter]
        public string Title { get; set; } = "Confirm";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback onConfirm { get; set; }

        [Parameter]
        public EventCallback onCancel { get; set; }

        private bool DisplayConfirmation = false;

        public void Show() => DisplayConfirmation = true;

        public void Hide() => DisplayConfirmation = false;
    }
}

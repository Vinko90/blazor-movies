using BlazorMovies.Client.Helpers.SweetAlert;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class Rating
    {
        [Inject]
        protected IDisplayMessage displayMessage { get; set; }

        [Parameter]
        public int MaximumRating { get; set; }

        [Parameter]
        public int SelectedRating { get; set; }

        [Parameter]
        public EventCallback<int> OnVote { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        private bool voted = false;

        private async Task OnClickHandle(int starNumber)
        {
            var authState = await AuthenticationState;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                await displayMessage.DisplayError("You must login in order to vote!");
                return;
            }

            SelectedRating = starNumber;
            voted = true;
            await OnVote.InvokeAsync(SelectedRating);
        }

        private void OnMouseOver(int starNumber)
        {
            if (!voted)
            {
                SelectedRating = starNumber;
            }
        }
    }
}

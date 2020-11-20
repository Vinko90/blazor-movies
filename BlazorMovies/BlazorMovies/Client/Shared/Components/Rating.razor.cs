using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class Rating
    {
        [Parameter]
        public int MaximumRating { get; set; }

        [Parameter]
        public int SelectedRating { get; set; }

        [Parameter]
        public EventCallback<int> OnVote { get; set; }

        private bool voted = false;

        private async Task OnClickHandle(int starNumber)
        {
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

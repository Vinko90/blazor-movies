using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class DetailsMovie
    {
        [Parameter]
        public int MovieId { get; set; }

        [Parameter]
        public string MovieName { get; set; }
    }
}
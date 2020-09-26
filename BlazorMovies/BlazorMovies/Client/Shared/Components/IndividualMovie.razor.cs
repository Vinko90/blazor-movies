using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class IndividualMovie
    {
        [Parameter]
        public Movie movie { get; set; }

        [Parameter]
        public EventCallback<Movie> DeleteMovie { get; set; }

        private string movieURL = string.Empty;

        protected override void OnInitialized()
        {
            movieURL = $"movie/{movie.Id}/{movie.Title.Replace(" ", "-")}";
        }
    }
}

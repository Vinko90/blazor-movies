using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Components.Shared
{
    public partial class IndividualMovie
    {
        private string movieURL = string.Empty;

        protected override void OnInitialized()
        {
            movieURL = $"movie/{Movie.Id}/{Movie.Title.Replace(" ", "-")}";
        }

        [Parameter]
        public Movie Movie { get; set; }

        [Parameter]
        public EventCallback<Movie> DeleteMovie { get; set; }
    }
}

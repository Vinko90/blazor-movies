using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class EditMovie
    {
        [Parameter]
        public int MovieId { get; set; }

        private Movie MovieItem;

        private List<Genre> NotSelectedGenre = new List<Genre>()
        {
            new Genre(){Id = 2, Name = "Comedy"},
            new Genre(){Id = 3, Name = "Drama"}
        };

        private List<Genre> SelectedGenre = new List<Genre>()
        {
            new Genre(){Id = 1, Name = "Action"}
        };

        protected override void OnInitialized()
        {
            MovieItem = new Movie() { Id = MovieId, Title = "HardCoded" };
        }

        private void EditMovieItem()
        {

        }
    }
}

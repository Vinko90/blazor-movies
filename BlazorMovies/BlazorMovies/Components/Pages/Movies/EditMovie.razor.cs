using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public partial class EditMovie
    {
        private Movie movieItem;
        private List<Genre> notSelectedGenre;
        private List<Genre> selectedGenre;
        private List<BlazorMovies.Shared.Entities.Person> SelectedActors;

        protected async override Task OnInitializedAsync()
        {
            var model = await MoviesRepository.GetMovieForUpdateAsync(MovieId);

            movieItem = model.MovieItem;
            notSelectedGenre = model.NotSelectedGenres;
            selectedGenre = model.SelectedGenres;
            SelectedActors = model.Actors;
        }

        private async Task EditMovieItem()
        {
            await MoviesRepository.UpdateMovie(movieItem);
            NavMan.NavigateTo($"movie/{MovieId}/{movieItem.Title.Replace(" ", " - ")}");
        }

        [Inject]
        public IMoviesRepository MoviesRepository { get; set; }

        [Inject]
        public NavigationManager NavMan { get; set; }

        [Parameter]
        public int MovieId { get; set; }
    }
}

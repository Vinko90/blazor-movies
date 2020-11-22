using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Movies
{
    public partial class DetailsMovie
    {
        [Inject]
        protected IDisplayMessage displayMessage { get; set; }

        [Inject]
        public IMoviesRepository movieRepository { get; set; }

        [Inject]
        public IRatingRepository ratingRepository { get; set; }

        [Parameter]
        public int MovieId { get; set; }

        [Parameter]
        public string MovieName { get; set; }

        private DetailsMovieDTO model;

        protected async override Task OnInitializedAsync()
        {
            model = await movieRepository.GetDetailsMovieDTOAsync(MovieId);
        }

        private async Task OnVote(int selectedRate)
        {
            model.UserVote = selectedRate;
            MovieRating movieRating = new MovieRating() { Rate = selectedRate, MovieId = MovieId };
            await ratingRepository.Vote(movieRating);
            await displayMessage.DisplaySuccess("Your vote has been received!");
        }
    }
}
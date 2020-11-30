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
        private DetailsMovieDTO model;

        protected async override Task OnInitializedAsync()
        {
            model = await MovieRepository.GetDetailsMovieDTOAsync(MovieId);
        }

        private async Task OnVote(int selectedRate)
        {
            model.UserVote = selectedRate;
            MovieRating movieRating = new MovieRating() { Rate = selectedRate, MovieId = MovieId };
            await RatingRepository.Vote(movieRating);
            await DisplayMessage.DisplaySuccess("Your vote has been received!");
        }

        [Inject]
        protected IDisplayMessage DisplayMessage { get; set; }

        [Inject]
        public IMoviesRepository MovieRepository { get; set; }

        [Inject]
        public IRatingRepository RatingRepository { get; set; }

        [Parameter]
        public int MovieId { get; set; }

        [Parameter]
        public string MovieName { get; set; }
    }
}
using BlazorMovies.Client.Helpers.SweetAlert;
using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class DetailsMovie
    {
        [Inject]
        protected IDisplayMessage displayMessage { get; set; }

        [Inject]
        public MoviesRepository movieRepository { get; set; }

        [Inject]
        public RatingRepository ratingRepository { get; set; }

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
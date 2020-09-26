using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class DetailsMovie
    {
        [Inject]
        public MoviesRepository movieRepository { get; set; }

        [Parameter]
        public int MovieId { get; set; }

        [Parameter]
        public string MovieName { get; set; }

        private DetailsMovieDTO model;

        protected async override Task OnInitializedAsync()
        {
            model = await movieRepository.GetDetailsMovieDTOAsync(MovieId);
        }
    }
}
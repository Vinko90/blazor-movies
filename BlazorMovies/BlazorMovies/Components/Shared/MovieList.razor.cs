using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Shared
{
    public partial class MovieList
    {
        [Inject]
        protected IJSRuntime js { get; set; }

        [Inject]
        public IMoviesRepository movieRepository { get; set; }

        [Parameter]
        public List<Movie> Movies { get; set; }

        private async Task DeleteMovie(Movie movie)
        {

            await js.MyFunction("Requested Movie delete");

            var result = await js.Confirm($"Are you sure you want to delete {movie.Title}?");

            if (result)
            {
                await movieRepository.DeleteMovie(movie.Id);
                Movies.Remove(movie);
            }
        }
    }
}

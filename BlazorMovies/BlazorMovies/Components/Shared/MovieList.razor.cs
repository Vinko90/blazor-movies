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
        private async Task DeleteMovie(Movie movie)
        {

            await Js.MyFunction("Requested Movie delete");

            var result = await Js.Confirm($"Are you sure you want to delete {movie.Title}?");

            if (result)
            {
                await MovieRepository.DeleteMovie(movie.Id);
                Movies.Remove(movie);
            }
        }

        [Inject]
        protected IJSRuntime Js { get; set; }

        [Inject]
        public IMoviesRepository MovieRepository { get; set; }

        [Parameter]
        public List<Movie> Movies { get; set; }
    }
}

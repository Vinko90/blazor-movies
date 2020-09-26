using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class MovieList
    {
        [Parameter]
        public List<Movie> Movies { get; set; }

        private async Task DeleteMovie(Movie movie)
        {

            await js.MyFunction("Requested Movie delete");

            var result = await js.Confirm($"Are you sure you want to delete {movie.Title}?");

            if (result)
            {
                Movies.Remove(movie);
            }
        }
    }
}

using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class CreateMovie
    {
        [Inject]
        protected MoviesRepository movieRepository { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }

        private Movie MovieItem = new Movie();

        private List<Genre> NotSelectedGenre = new List<Genre>()
        {
            new Genre(){Id = 1, Name = "Action"},
            new Genre(){Id = 2, Name = "Comedy"},
            new Genre(){Id = 3, Name = "Drama"}
        };

        private async Task SaveMovie()
        {
            try
            {
                var movieId = await movieRepository.CreateMovie(MovieItem);
                NavMan.NavigateTo($"movie/{movieId}/{MovieItem.Title.Replace(" ", "-")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public partial class CreateMovie
    {
        [Inject]
        protected MoviesRepository movieRepository { get; set; }

        [Inject]
        protected GenreRepository genreRepository { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }

        private Movie MovieItem = new Movie();

        private List<Genre> NotSelectedGenre;

        protected override async Task OnInitializedAsync()
        {
            NotSelectedGenre = await genreRepository.GetGenres();
        }

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
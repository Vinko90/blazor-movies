using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public partial class CreateMovie
    {
        private readonly Movie movieItem = new Movie();

        private List<Genre> notSelectedGenre;

        protected override async Task OnInitializedAsync()
        {
            notSelectedGenre = await GenreRepository.GetGenres();
        }

        private async Task SaveMovie()
        {
            try
            {
                var movieId = await MovieRepository.CreateMovie(movieItem);
                NavMan.NavigateTo($"movie/{movieId}/{movieItem.Title.Replace(" ", "-")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        [Inject]
        protected IMoviesRepository MovieRepository { get; set; }

        [Inject]
        protected IGenreRepository GenreRepository { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }
    }
}
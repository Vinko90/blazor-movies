using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Genres
{
    [Authorize(Roles = "Admin")]
    public partial class IndexGenres
    {
        private List<Genre> GenresList;

        [Inject]
        protected IGenreRepository genreRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                GenresList = await genreRepository.GetGenres();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async Task DeleteGenre(int id)
        {
            await genreRepository.DeleteGenre(id);
            GenresList = await genreRepository.GetGenres();
        }
    }
}

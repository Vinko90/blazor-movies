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
        private List<Genre> genresList;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                genresList = await GenreRepository.GetGenres();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async Task DeleteGenre(int id)
        {
            await GenreRepository.DeleteGenre(id);
            genresList = await GenreRepository.GetGenres();
        }

        [Inject]
        protected IGenreRepository GenreRepository { get; set; }
    }
}

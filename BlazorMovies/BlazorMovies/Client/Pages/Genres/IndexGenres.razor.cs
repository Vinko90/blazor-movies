using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Genres
{
    public partial class IndexGenres
    {
        private List<Genre> GenresList;

        [Inject]
        protected GenreRepository genreRepository { get; set; }

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

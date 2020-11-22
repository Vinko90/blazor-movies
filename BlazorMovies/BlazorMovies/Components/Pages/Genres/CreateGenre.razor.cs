using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Genres
{
    [Authorize(Roles = "Admin")]
    public partial class CreateGenre
    {
        private Genre genre = new Genre();

        [Inject]
        protected IGenreRepository genreRepository { get; set; }

        [Inject]
        protected NavigationManager navMan { get; set; }

        private async Task Create()
        {
            try
            {
                await genreRepository.CreateGenre(genre);
                navMan.NavigateTo("genres");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}

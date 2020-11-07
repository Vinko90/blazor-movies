using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Genres
{
    [Authorize]
    public partial class CreateGenre
    {
        private Genre genre = new Genre();

        [Inject]
        protected GenreRepository genreRepository { get; set; }

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

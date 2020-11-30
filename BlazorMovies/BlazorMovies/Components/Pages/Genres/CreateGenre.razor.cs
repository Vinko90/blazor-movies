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
        private readonly Genre genre = new Genre();

        private async Task Create()
        {
            try
            {
                await GenreRepository.CreateGenre(genre);
                NavMan.NavigateTo("genres");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        [Inject]
        protected IGenreRepository GenreRepository { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }
    }
}

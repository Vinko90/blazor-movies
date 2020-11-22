using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Genres
{
    [Authorize(Roles = "Admin")]
    public partial class EditGenre
    {
        [Inject]
        public IGenreRepository genreRepository { get; set; }

        [Inject]
        public NavigationManager navMan { get; set; }

        [Parameter]
        public int GenreId { get; set; }

        private Genre genre;

        protected override async Task OnInitializedAsync()
        {
            genre = await genreRepository.GetGenre(GenreId);
        }

        private async Task Edit()
        {
            await genreRepository.UpdateGenre(genre);
            navMan.NavigateTo("genres");
        }
    }
}

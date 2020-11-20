using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Genres
{
    [Authorize(Roles = "Admin")]
    public partial class EditGenre
    {
        [Inject]
        public GenreRepository genreRepository { get; set; }

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

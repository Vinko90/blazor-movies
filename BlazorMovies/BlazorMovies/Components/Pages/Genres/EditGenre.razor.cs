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
        private Genre genre;

        protected override async Task OnInitializedAsync()
        {
            genre = await GenreRepository.GetGenre(GenreId);
        }

        private async Task Edit()
        {
            await GenreRepository.UpdateGenre(genre);
            NavMan.NavigateTo("genres");
        }

        [Inject]
        public IGenreRepository GenreRepository { get; set; }

        [Inject]
        public NavigationManager NavMan { get; set; }

        [Parameter]
        public int GenreId { get; set; }
    }
}

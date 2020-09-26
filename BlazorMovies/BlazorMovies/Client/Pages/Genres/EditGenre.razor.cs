using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorMovies.Client.Pages.Genres
{
    public partial class EditGenre
    {
        [Parameter]
        public int GenreId { get; set; }

        private Genre genre;

        protected override void OnInitialized()
        {
            genre = new Genre() { Id = GenreId, Name = "Comedy" };
        }

        private void Edit()
        {
            Console.WriteLine("Edit hit");
        }
    }
}

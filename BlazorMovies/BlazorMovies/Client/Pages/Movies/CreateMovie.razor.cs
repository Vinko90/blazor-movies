using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class CreateMovie
    {
        [Inject]
        protected NavigationManager NavMan { get; set; }

        private Movie MovieItem = new Movie();

        private List<Genre> NotSelectedGenre = new List<Genre>()
        {
            new Genre(){Id = 1, Name = "Action"},
            new Genre(){Id = 2, Name = "Comedy"},
            new Genre(){Id = 3, Name = "Drama"}
        };

        private void SaveMovie()
        {
            //Save procedure
            Console.WriteLine(NavMan.Uri);
            NavMan.NavigateTo("movie");
        }
    }
}
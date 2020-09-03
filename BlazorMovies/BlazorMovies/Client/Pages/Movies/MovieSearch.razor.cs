using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class MovieSearch
    {
        private string Title = "";
        private string SelectedGenre = "0";
        private List<Genre> GenresList = new List<Genre>();
        private bool UpcomingReleases = false;
        private bool InTheaters = false;
        private List<Movie> MoviesList;
        

        private void TitleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {

            }
        }

        private void SearchForMovies()
        {

        }

        private void Clear()
        {

        }
    }
}
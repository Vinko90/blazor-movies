using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Movies
{
    public partial class MovieSearch
    {
        private int totalAmountOfPages;
        private List<Genre> genresList = new List<Genre>();
        private List<Movie> moviesList = new List<Movie>();
        private readonly FilterMoviesDTO filteredMoviesDTO = new FilterMoviesDTO() { RecordsPerPage = 10};

        protected async override Task OnInitializedAsync()
        {
            var queryStrings = NavMan.GetQueryStrings(NavMan.Uri);
            
            genresList = await GenreRepository.GetGenres();

            if (queryStrings != null)
            {
                FillFilterWithQueryStrings(queryStrings);
            }

            await LoadMovies();
        }

        private void FillFilterWithQueryStrings(Dictionary<string, string> queryStrings)
        {
            if (queryStrings.ContainsKey("genreId"))
            {
                filteredMoviesDTO.GenreId = int.Parse(queryStrings["genreId"]);
            }

            if (queryStrings.ContainsKey("title"))
            {
                filteredMoviesDTO.Title = queryStrings["title"];
            }

            if (queryStrings.ContainsKey("intheaters"))
            {
                filteredMoviesDTO.InTheaters = bool.Parse(queryStrings["intheaters"]);
            }

            if (queryStrings.ContainsKey("upcomingReleases"))
            {
                filteredMoviesDTO.UpcomingReleases = bool.Parse(queryStrings["upcomingReleases"]);
            }

            if (queryStrings.ContainsKey("page"))
            {
                filteredMoviesDTO.Page = int.Parse(queryStrings["page"]);
            }
        }

        private async Task SelectedPage(int page)
        {
            filteredMoviesDTO.Page = page;
            await LoadMovies();
        }

        private async Task LoadMovies()
        {
            var queryString = GenerateQueryString();
            if (!string.IsNullOrWhiteSpace(queryString))
            {
                queryString = $"?{queryString}";
                NavMan.NavigateTo("movies/search" + queryString);
            }
            var paginatedResponse = await MovieRepository.GetMoviesFiltered(filteredMoviesDTO);
            moviesList = paginatedResponse.Response;
            totalAmountOfPages = paginatedResponse.TotalAmountOfPages;
        }

        private string GenerateQueryString()
        {
            var defaultValue = new List<string>() { "false", "", "0" };

            var queryStringsDict = new Dictionary<string, string>
            {
                ["genreId"] = filteredMoviesDTO.GenreId.ToString(),
                ["title"] = filteredMoviesDTO.Title ?? "",
                ["intheaters"] = filteredMoviesDTO.InTheaters.ToString(),
                ["upcomingReleases"] = filteredMoviesDTO.UpcomingReleases.ToString(),
                ["page"] = filteredMoviesDTO.Page.ToString()
            };

            //Generate query string => genreId=4&title=spider...

            return string.Join("&", queryStringsDict
                .Where(x => !defaultValue.Contains(x.Value.ToLower()))
                .Select(x => $"{x.Key}={System.Web.HttpUtility.UrlEncode(x.Value)}").ToArray());
        }

        private async Task TitleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await SearchForMovies();
            }
        }

        private async Task SearchForMovies()
        {
            await LoadMovies();
        }

        private async Task Clear()
        {
            filteredMoviesDTO.Title = "";
            filteredMoviesDTO.GenreId = 0;
            filteredMoviesDTO.UpcomingReleases = false;
            filteredMoviesDTO.InTheaters = false;
            await SearchForMovies();
        }

        [Inject]
        public IMoviesRepository MovieRepository { get; set; }

        [Inject]
        public IGenreRepository GenreRepository { get; set; }

        [Inject]
        public NavigationManager NavMan { get; set; }
    }
}
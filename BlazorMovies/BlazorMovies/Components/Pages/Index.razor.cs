using BlazorMovies.Shared.Entities;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages
{
    public partial class Index
    {
        private List<Movie> inTheaters;
        private List<Movie> upcomingReleases;

        protected async override Task OnInitializedAsync()
        {
            var response = await MoviesRepository.GetIndexPageDTOAsync();

            inTheaters = response.InTheathers;
            upcomingReleases = response.UpcomingReleases;
        }

        private async Task<IEnumerable<string>> SearchMethod(string searchText)
        {
            await Task.Delay(2000);

            if (searchText == "test")
            {
                return Enumerable.Empty<string>();
            }

            return new List<string>() { "Test1", "Test2", "Test3" };
        }

        [Inject]
        public IMoviesRepository MoviesRepository { get; set; }
    }
}

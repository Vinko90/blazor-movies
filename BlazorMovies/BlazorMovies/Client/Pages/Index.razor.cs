using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public MoviesRepository moviesRepository { get; set; }

        private List<Movie> InTheaters;

        private List<Movie> UpcomingReleases;

        protected async override Task OnInitializedAsync()
        {
            var response = await moviesRepository.GetIndexPageDTOAsync();

            InTheaters = response.InTheathers;
            UpcomingReleases = response.UpcomingReleases;
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
    }
}

using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class MoviesRepository
    {
        private readonly IHttpService httpService;

        private readonly string url = "api/movies";

        public MoviesRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IndexPageDTO> GetIndexPageDTOAsync()
        {
            return await Get<IndexPageDTO>(url);
        }

        public async Task<DetailsMovieDTO> GetDetailsMovieDTOAsync(int id)
        {
            return await Get<DetailsMovieDTO>($"{url}/{id}");
        }

        public async Task<int> CreateMovie(Movie movie)
        {
            var response = await httpService.Post<Movie, int>(url, movie);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        #region Private

        private async Task<T> Get<T>(string url)
        {
            var response = await httpService.Get<T>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        #endregion
    }
}

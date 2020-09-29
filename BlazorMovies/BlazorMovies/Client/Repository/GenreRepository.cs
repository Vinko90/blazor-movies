using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class GenreRepository
    {
        private readonly IHttpService httpService;

        private readonly string url = "api/genres";

        public GenreRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Genre>> GetGenres()
        {
            var response = await httpService.Get<List<Genre>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<Genre> GetGenre(int id)
        {
            var response = await httpService.Get<Genre>($"{url}/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task CreateGenre(Genre genre)
        {
            var response = await httpService.Post(url, genre);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateGenre(Genre genre)
        {
            var response = await httpService.Put(url, genre);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        
        public async Task DeleteGenre(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}

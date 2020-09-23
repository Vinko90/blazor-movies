﻿using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using System;
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

        public async Task CreateGenre(Genre genre)
        {
            var response = await httpService.Post(url, genre);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}

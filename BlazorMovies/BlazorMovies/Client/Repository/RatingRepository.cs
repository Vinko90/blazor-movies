using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class RatingRepository
    {
        private readonly string urlBase = "api/rating";
        private readonly IHttpService httpService;

        public RatingRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task Vote(MovieRating movieRating)
        {
            var httpResponse = await httpService.Post(urlBase, movieRating);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }
        }
    }
}

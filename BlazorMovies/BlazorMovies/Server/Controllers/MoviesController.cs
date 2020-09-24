using BlazorMovies.Server.DataContext;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext dbcontext;
        private readonly IFileStorageService fileStorageService;

        public MoviesController(AppDbContext context, IFileStorageService fileStorageService)
        {
            dbcontext = context;
            this.fileStorageService = fileStorageService;
        }

        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var personPicture = Convert.FromBase64String(movie.Poster);
                movie.Poster = await fileStorageService.SaveFile(personPicture, "jpg", "img_movies");
            }

            dbcontext.Add(movie);
            await dbcontext.SaveChangesAsync();
            return movie.Id;
        }
    }
}

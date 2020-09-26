using BlazorMovies.Server.DataContext;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        [HttpGet]
        public async Task<ActionResult<IndexPageDTO>> Get()
        {
            int recordsLimit = 6;

            var moviesInTheater = await dbcontext.MoviesRecords
                .Where(x => x.InTheaters).Take(recordsLimit)
                .OrderByDescending(x => x.ReleaseDate)
                .ToListAsync();

            var upcomingReleases = await dbcontext.MoviesRecords
                .Where(x => x.ReleaseDate > DateTime.Today)
                .OrderBy(x => x.ReleaseDate).Take(recordsLimit)
                .ToListAsync();

            var responseObject = new IndexPageDTO();
            responseObject.InTheathers = moviesInTheater;
            responseObject.UpcomingReleases = upcomingReleases;

            return responseObject;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var personPicture = Convert.FromBase64String(movie.Poster);
                movie.Poster = await fileStorageService.SaveFile(personPicture, "jpg", "img_movies");
            }

            if (movie.ActorList != null)
            {
                for (int i = 0; i < movie.ActorList.Count; i++)
                {
                    movie.ActorList[i].Order = i + 1;
                }
            }

            dbcontext.Add(movie);
            await dbcontext.SaveChangesAsync();
            return movie.Id;
        }
    }
}

using AutoMapper;
using BlazorMovies.DataAccess;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class MoviesController : ControllerBase
    {
        private readonly string MovieImageContainerName = "img_movies";
        private readonly AppDbContext dbcontext;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public MoviesController(AppDbContext context, IFileStorageService fileStorageService, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            dbcontext = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
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

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DetailsMovieDTO>> Get(int id)
        {
            var movie = await dbcontext.MoviesRecords.Where(x => x.Id == id)
                .Include(x => x.GenresList).ThenInclude(x => x.Genre)
                .Include(x => x.ActorList).ThenInclude(x => x.Person)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return NotFound();
            }

            var voteAverage = 0.0;
            var userRating = 0;

            if (await dbcontext.MovieRatings.AnyAsync(x => x.MovieId == id))
            {
                voteAverage = await dbcontext.MovieRatings.Where(x => x.MovieId == id).AverageAsync(x => x.Rate);

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = await userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
                    var userId = user.Id;

                    var userVoteFromDb = await dbcontext.MovieRatings.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == userId);

                    if (userVoteFromDb != null)
                    {
                        userRating = userVoteFromDb.Rate;
                    }
                }
            }

            movie.ActorList = movie.ActorList.OrderBy(x => x.Order).ToList();

            var model = new DetailsMovieDTO
            {
                MovieItem = movie,
                Genres = movie.GenresList.Select(x => x.Genre).ToList(),
                Actors = movie.ActorList.Select(x =>
                    new Person
                    {
                        Name = x.Person.Name,
                        Picture = x.Person.Picture,
                        Character = x.CharacterName,
                        Id = x.PersonId
                    }).ToList(),
                UserVote = userRating,
                AverageVote = voteAverage
            };

            return model;
        }

        [HttpPost("filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Movie>>> Filter(FilterMoviesDTO filter)
        {
            var moviesQueryable = dbcontext.MoviesRecords.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                moviesQueryable = moviesQueryable
                    .Where(x => x.Title.Contains(filter.Title));
            }

            if (filter.InTheaters)
            {
                moviesQueryable = moviesQueryable.Where(x => x.InTheaters);
            }

            if (filter.UpcomingReleases)
            {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(x => x.ReleaseDate > today);
            }

            if (filter.GenreId != 0)
            {
                moviesQueryable = moviesQueryable
                    .Where(x => x.GenresList.Select(y => y.GenreId)
                    .Contains(filter.GenreId));
            }

            await HttpContext.InsertPaginationParametersInReponse(moviesQueryable, filter.RecordsPerPage);

            var movies = await moviesQueryable.Paginate(filter.Pagination).ToListAsync();

            return movies;
        }


        [HttpGet("update/{id}")]
        public async Task<ActionResult<MovieUpdateDTO>> PutGet(int id)
        {
            var movieActionResult = await Get(id);
            if (movieActionResult.Result is NotFoundResult) { return NotFound(); }

            var movieDetailDTO = movieActionResult.Value;
            var selectedGenresIds = movieDetailDTO.Genres.Select(x => x.Id).ToList();
            
            var notSelectedGenres = await dbcontext.GenresRecords
                .Where(x => !selectedGenresIds.Contains(x.Id))
                .ToListAsync();

            MovieUpdateDTO model = new MovieUpdateDTO
            {
                MovieItem = movieDetailDTO.MovieItem,
                SelectedGenres = movieDetailDTO.Genres,
                NotSelectedGenres = notSelectedGenres,
                Actors = movieDetailDTO.Actors
            };

            return model;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var personPicture = Convert.FromBase64String(movie.Poster);
                movie.Poster = await fileStorageService.SaveFile(personPicture, "jpg", MovieImageContainerName);
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

        [HttpPut]
        public async Task<ActionResult> Put(Movie movie)
        {
            var movieDB = await dbcontext.MoviesRecords.FirstOrDefaultAsync(x => x.Id == movie.Id);

            if (movieDB == null) { return NotFound(); }

            movieDB = mapper.Map(movie, movieDB);

            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var moviePoster = Convert.FromBase64String(movie.Poster);
                movieDB.Poster = await fileStorageService.EditFile(moviePoster, "jpg", MovieImageContainerName, movieDB.Poster);
            }

            await dbcontext.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM MoviesActorsRecords WHERE MovieId = {movie.Id};");
            await dbcontext.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM MoviesGenresRecords WHERE MovieId = {movie.Id};");

            if (movie.ActorList != null)
            {
                for (int i = 0; i < movie.ActorList.Count; i++)
                {
                    movie.ActorList[i].Order = i + 1;
                }
            }

            movieDB.ActorList = movie.ActorList;
            movieDB.GenresList = movie.GenresList;

            await dbcontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await dbcontext.MoviesRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) { return NotFound(); }

            dbcontext.Remove(movie);
            await dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}

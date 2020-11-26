using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    /// <summary>
    /// IMoviesRepository repository pattern interface.
    /// </summary>
    public interface IMoviesRepository
    {
        /// <summary>
        /// Create a new movie in the database
        /// </summary>
        /// <param name="movie">Movie object to be created</param>
        /// <returns>This Task success status</returns>
        Task<int> CreateMovie(Movie movie);

        /// <summary>
        /// Delete a movie from the database.
        /// </summary>
        /// <param name="id">Movie primary key</param>
        /// <returns>This Task success status</returns>
        Task DeleteMovie(int id);

        /// <summary>
        /// Get details for a given movie.
        /// </summary>
        /// <param name="id">Movie primary key</param>
        /// <returns>This Task success status</returns>
        Task<DetailsMovieDTO> GetDetailsMovieDTOAsync(int id);

        /// <summary>
        /// Get the two list of in theaters and upcoming releases movies.
        /// </summary>
        /// <returns>This Task success status</returns>
        Task<IndexPageDTO> GetIndexPageDTOAsync();

        /// <summary>
        /// Get a movie to be updated from the database.
        /// </summary>
        /// <param name="id">Movie primary key</param>
        /// <returns>This Task success status</returns>
        Task<MovieUpdateDTO> GetMovieForUpdateAsync(int id);

        /// <summary>
        /// Search in the database for movies with a given set of parameters.
        /// </summary>
        /// <param name="filter">Filter parameters</param>
        /// <returns>This Task success status</returns>
        Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filter);

        /// <summary>
        /// Update a movie in the database.
        /// </summary>
        /// <param name="movie">The movie object to be updated</param>
        /// <returns>This Task success status</returns>
        Task UpdateMovie(Movie movie);
    }
}
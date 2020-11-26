using BlazorMovies.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    /// <summary>
    /// IGenreRepository repository pattern interface.
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Create a new genre in the database.
        /// </summary>
        /// <param name="genre">Genre object to be created</param>
        /// <returns>This Task success status</returns>
        Task CreateGenre(Genre genre);

        /// <summary>
        /// Delete a genre from the database.
        /// </summary>
        /// <param name="id">Genre primary key</param>
        /// <returns>This Task success status</returns>
        Task DeleteGenre(int id);

        /// <summary>
        /// Get a genre from the database.
        /// </summary>
        /// <param name="id">Genre primary key</param>
        /// <returns>This Task success status</returns>
        Task<Genre> GetGenre(int id);

        /// <summary>
        /// Get all the genres from the database.
        /// </summary>
        /// <returns>This Task success status</returns>
        Task<List<Genre>> GetGenres();

        /// <summary>
        /// Update a genre in the database.
        /// </summary>
        /// <param name="genre">The updated genre object</param>
        /// <returns>This Task success status</returns>
        Task UpdateGenre(Genre genre);
    }
}
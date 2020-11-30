using BlazorMovies.Shared.Entities;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    /// <summary>
    /// IRatingRepository repository pattern interface
    /// </summary>
    public interface IRatingRepository
    {
        /// <summary>
        /// Set the user rating vote for a given movie
        /// </summary>
        /// <param name="movieRating">Movie rating object</param>
        /// <returns>This task result status</returns>
        Task Vote(MovieRating movieRating);
    }
}
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    public interface IMoviesRepository
    {
        Task<int> CreateMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<DetailsMovieDTO> GetDetailsMovieDTOAsync(int id);
        Task<IndexPageDTO> GetIndexPageDTOAsync();
        Task<MovieUpdateDTO> GetMovieForUpdateAsync(int id);
        Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filter);
        Task UpdateMovie(Movie movie);
    }
}
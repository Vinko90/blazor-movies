using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Client.Helpers
{
    public interface IRepository
    {
        List<Movie> GetMovies();
    }
}

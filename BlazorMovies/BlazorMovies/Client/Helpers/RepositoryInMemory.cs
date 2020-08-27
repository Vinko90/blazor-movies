using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie() {Title = "Spiderman", ReleaseDate = new DateTime(2019, 7, 14)},
                new Movie() {Title = "The Hobbit", ReleaseDate = new DateTime(2012, 12, 2)},
                new Movie() {Title = "Harry Potter", ReleaseDate = new DateTime(2001, 3, 21)}
            };
        }
    }
}

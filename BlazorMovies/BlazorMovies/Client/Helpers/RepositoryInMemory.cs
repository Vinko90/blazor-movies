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
                new Movie() 
                {
                    Title = "Spider-Man", 
                    ReleaseDate = new DateTime(2002, 7, 4),
                    Poster = "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
                new Movie() 
                {
                    Title = "The Hobbit: An Unexpected Journey", 
                    ReleaseDate = new DateTime(2012, 12, 12),
                    Poster = "https://m.media-amazon.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
                new Movie() 
                {
                    Title = "Harry Potter and the Sorcerer's Stone", 
                    ReleaseDate = new DateTime(2001, 11, 22),
                    Poster = "https://m.media-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_UX182_CR0,0,182,268_AL_.jpg"
                }
            };
        }
    }
}

using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Shared.DataTransferObjects
{
    public class MovieUpdateDTO
    {
        public Movie MovieItem { get; set; }

        public List<Person> Actors { get; set; }

        public List<Genre> SelectedGenres { get; set; }

        public List<Genre> NotSelectedGenres { get; set; }
    }
}

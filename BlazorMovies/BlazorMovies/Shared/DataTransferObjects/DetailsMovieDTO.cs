﻿using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Shared.DataTransferObjects
{
    public class DetailsMovieDTO
    {
        public Movie MovieItem { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Person> Actors { get; set; }
    }
}

using BlazorMovies.Shared.Entities;
using System.Collections.Generic;

namespace BlazorMovies.Shared.DataTransferObjects
{
    public class IndexPageDTO
    {
        public List<Movie> InTheathers { get; set; }

        public List<Movie> UpcomingReleases { get; set; }
    }
}
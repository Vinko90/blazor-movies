namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// FilterMoviesDTO class implementation. Used to filter movie with pagination.
    /// </summary>
    public class FilterMoviesDTO
    {
        /// <summary>
        /// Page number. Default set on single page.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Amount of records to show on each page. Default set on 10 records.
        /// </summary>
        public int RecordsPerPage { get; set; } = 10;

        /// <summary>
        /// Pagination object.
        /// </summary>
        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }

        /// <summary>
        /// Movie title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Genre Id primary in which the movies should be filtered on.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Set true to filter in theater movies.
        /// </summary>
        public bool InTheaters { get; set; }

        /// <summary>
        /// Set true to filter upcoming releases movies.
        /// </summary>
        public bool UpcomingReleases { get; set; }
    }
}

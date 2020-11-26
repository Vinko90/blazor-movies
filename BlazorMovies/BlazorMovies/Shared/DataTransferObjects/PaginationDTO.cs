namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// PaginationDTO class implementation
    /// </summary>
    public class PaginationDTO
    {
        /// <summary>
        /// Page number. Default 1 page.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Amount of records per page. Default 10 records.
        /// </summary>
        public int RecordsPerPage { get; set; } = 10;
    }
}

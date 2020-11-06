namespace BlazorMovies.Shared.DataTransferObjects
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;
    }
}

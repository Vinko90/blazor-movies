namespace BlazorMovies.Shared.DataTransferObjects
{
    public class PaginatedResponse<T>
    {
        public T Response { get; set; }

        public int TotalAmountOfPages { get; set; }
    }
}

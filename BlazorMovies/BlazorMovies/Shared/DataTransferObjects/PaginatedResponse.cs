namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// PaginatedResponse class implementation. Used for paginating items on a page.
    /// </summary>
    /// <typeparam name="T">Generic Entity type</typeparam>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// The received entity type
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// Total amount of pages needed to display all the items
        /// </summary>
        public int TotalAmountOfPages { get; set; }
    }
}

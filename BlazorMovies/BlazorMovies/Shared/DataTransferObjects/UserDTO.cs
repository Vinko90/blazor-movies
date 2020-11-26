namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// UserDTO class implementation.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// User Id primary key.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User e-mail address
        /// </summary>
        public string Email { get; set; }
    }
}

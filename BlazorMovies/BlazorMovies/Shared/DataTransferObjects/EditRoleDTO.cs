namespace BlazorMovies.Shared.DataTransferObjects
{
    /// <summary>
    /// EditRoleDTO class implementation. Used for editing a Role from the client page.
    /// </summary>
    public class EditRoleDTO
    {
        /// <summary>
        /// User Id primary key
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Role name string
        /// </summary>
        public string RoleName { get; set; }
    }
}

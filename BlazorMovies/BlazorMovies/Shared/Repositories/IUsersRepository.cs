using BlazorMovies.Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Repositories
{
    /// <summary>
    /// IUsersRepository repository pattern interface
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Assign a system role to a specific user
        /// </summary>
        /// <param name="editRole">Edit Role object item</param>
        /// <returns>This task result status</returns>
        Task AssignRole(EditRoleDTO editRole);
        
        /// <summary>
        /// Get all the roles from the database for the current system
        /// </summary>
        /// <returns>A list of roles</returns>
        Task<List<RoleDTO>> GetRoles();
        
        /// <summary>
        /// Get all the users from the database formatted with pagination
        /// </summary>
        /// <param name="paginationSettings">Pagination parameters</param>
        /// <returns>List of pagined users</returns>
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationSettings);

        /// <summary>
        /// Remove a role from the current system
        /// </summary>
        /// <param name="editRole">Role object item</param>
        /// <returns>This task result status</returns>
        Task RemoveRole(EditRoleDTO editRole);
    }
}
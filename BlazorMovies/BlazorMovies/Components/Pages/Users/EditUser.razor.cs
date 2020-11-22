using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public partial class EditUser
    {
        [Inject]
        protected IUsersRepository usersRepository { get; set; }

        [Inject]
        protected IDisplayMessage displayMessage { get; set; }

        [Parameter]
        public string UserId { get; set; }

        private List<RoleDTO> roles = new List<RoleDTO>();

        private string selectedRole = "0";

        protected override async Task OnInitializedAsync()
        {
            roles = await usersRepository.GetRoles();
        }

        private async Task AssignRole()
        {
            if (selectedRole == "0")
            {
                await displayMessage.DisplayError("You must select a role");
                return;
            }

            await usersRepository.AssignRole(new EditRoleDTO() { RoleName = selectedRole, UserId = UserId });
            await displayMessage.DisplaySuccess("Role assigned");
        }

        private async Task RemoveRole()
        {
            if (selectedRole == "0")
            {
                await displayMessage.DisplayError("You must select a role");
                return;
            }

            await usersRepository.RemoveRole(new EditRoleDTO() { RoleName = selectedRole, UserId = UserId });
            await displayMessage.DisplaySuccess("Role removed");
        }
    }
}

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
        private List<RoleDTO> roles = new List<RoleDTO>();
        private string selectedRole = "0";

        protected override async Task OnInitializedAsync()
        {
            roles = await UsersRepository.GetRoles();
        }

        private async Task AssignRole()
        {
            if (selectedRole == "0")
            {
                await DisplayMessage.DisplayError("You must select a role");
                return;
            }

            await UsersRepository.AssignRole(new EditRoleDTO() { RoleName = selectedRole, UserId = UserId });
            await DisplayMessage.DisplaySuccess("Role assigned");
        }

        private async Task RemoveRole()
        {
            if (selectedRole == "0")
            {
                await DisplayMessage.DisplayError("You must select a role");
                return;
            }

            await UsersRepository.RemoveRole(new EditRoleDTO() { RoleName = selectedRole, UserId = UserId });
            await DisplayMessage.DisplaySuccess("Role removed");
        }

        [Inject]
        protected IUsersRepository UsersRepository { get; set; }

        [Inject]
        protected IDisplayMessage DisplayMessage { get; set; }

        [Parameter]
        public string UserId { get; set; }
    }
}

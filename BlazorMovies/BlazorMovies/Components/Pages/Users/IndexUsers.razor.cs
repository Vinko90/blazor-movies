using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public partial class IndexUsers
    {
        private List<UserDTO> users;
        private readonly PaginationDTO paginationDTO = new PaginationDTO();
        private int totalAmountOfPages;

        protected override async Task OnInitializedAsync()
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var paginatedResponse = await UsersRepository.GetUsers(paginationDTO);
            users = paginatedResponse.Response;
            totalAmountOfPages = paginatedResponse.TotalAmountOfPages;
        }

        private async Task SelectedPage(int page)
        {
            paginationDTO.Page = page;
            await LoadUsers();
        }

        [Inject]
        protected IUsersRepository UsersRepository { get; set; }
    }
}

using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public partial class IndexUsers
    {
        [Inject]
        protected UsersRepository usersRepository { get; set; }

        private List<UserDTO> Users;
        private PaginationDTO paginationDTO = new PaginationDTO();
        private int totalAmountOfPages;

        protected override async Task OnInitializedAsync()
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var paginatedResponse = await usersRepository.GetUsers(paginationDTO);
            Users = paginatedResponse.Response;
            totalAmountOfPages = paginatedResponse.TotalAmountOfPages;
        }

        private async Task SelectedPage(int page)
        {
            paginationDTO.Page = page;
            await LoadUsers();
        }
    }
}

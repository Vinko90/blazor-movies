using BlazorMovies.Client.Auth;
using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Auth
{
    public partial class Login
    {
        [Inject]
        protected AccountsRepository accountsRepository { get; set; }

        [Inject]
        protected NavigationManager navMan { get; set; }

        [Inject]
        protected ILoginService loginService { get; set; }

        private UserInfo userInfo = new UserInfo();

        private async Task LoginUser()
        {
            var userToken = await accountsRepository.Login(userInfo);
            await loginService.Login(userToken.Token);
            navMan.NavigateTo("");
        }
    }
}

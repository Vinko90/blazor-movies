using BlazorMovies.Client.Auth;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Auth
{
    public partial class Logout
    {
        [Inject]
        protected ILoginService loginService { get; set; }

        [Inject]
        protected NavigationManager navMan { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await loginService.Logout();
            navMan.NavigateTo("");
        }
    }
}

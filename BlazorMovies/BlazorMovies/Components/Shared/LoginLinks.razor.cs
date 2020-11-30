using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Shared
{
    public partial class LoginLinks
    {
        private async Task BeginSignOut(MouseEventArgs args)
        {
            await SignOutManager.SetSignOutState();
            NavMan.NavigateTo("authentication/logout");
        }

        [Inject]
        protected NavigationManager NavMan { get; set; }

        [Inject]
        protected SignOutSessionStateManager SignOutManager { get; set; }
    }
}

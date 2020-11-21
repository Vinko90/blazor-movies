using BlazorMovies.Client.Auth;
using BlazorMovies.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        protected TokenRenewer TokenRenewer { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }

        [Inject]
        protected IJSRuntime Js { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Js.InitializeInactivityTimer(DotNetObjectReference.Create(this));
            TokenRenewer.Initiate();
        }

        [JSInvokable]
        public async Task Logout()
        {
            var authState = await AuthenticationState;
            if (authState.User.Identity.IsAuthenticated)
            {
                NavMan.NavigateTo("logout");
            }
        }
    }
}

using BlazorMovies.Client.Auth;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        protected TokenRenewer TokenRenewer { get; set; }

        protected override void OnInitialized()
        {
            TokenRenewer.Initiate();
        }
    }
}

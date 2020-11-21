using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Pages.Auth
{
    public partial class Authentication
    {
        [Inject]
        protected NavigationManager NavMan { get; set; }

        [Parameter]
        public string Action { get; set; }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorMovies.Components.Shared
{
    public partial class CultureSelector
    {
        [Inject]
        protected IJSRuntime js { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }

        private readonly CultureInfo[] cultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("it-IT")
        };

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                var jsInProcessRuntime = (IJSInProcessRuntime)js;
                jsInProcessRuntime.InvokeVoid("setInLocalStorage", "culture", value.Name);
                NavMan.NavigateTo(NavMan.Uri, forceLoad: true);
            }
        }
    }
}

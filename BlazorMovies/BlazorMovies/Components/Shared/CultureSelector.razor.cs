using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorMovies.Components.Shared
{
    public partial class CultureSelector
    {
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
                var jsInProcessRuntime = (IJSInProcessRuntime)Js;
                jsInProcessRuntime.InvokeVoid("setInLocalStorage", "culture", value.Name);
                NavMan.NavigateTo(NavMan.Uri, forceLoad: true);
            }
        }

        [Inject]
        protected IJSRuntime Js { get; set; }

        [Inject]
        protected NavigationManager NavMan { get; set; }
    }
}

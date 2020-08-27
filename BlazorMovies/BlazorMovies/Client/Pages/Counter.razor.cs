using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using static BlazorMovies.Client.Shared.MainLayout;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        /// <summary>
        /// Example how to move DI code from the razor component to the partial class
        /// </summary>
        [Inject]
        TransientService Transient { get; set; }

        [Inject]
        IJSRuntime js { get; set; }

        [CascadingParameter]
        public AppState AppState { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCountAsync()
        {
            currentCount++;
            currentCountStatic++;
            singleton.Value = currentCount;
            Transient.Value = currentCount;

            await js.InvokeVoidAsync("dotNetStaticInvocation");
        }

        private async Task IncrementCountAsyncFromJavascript()
        {
            await js.InvokeVoidAsync("dotNetInstanceInvocation", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}

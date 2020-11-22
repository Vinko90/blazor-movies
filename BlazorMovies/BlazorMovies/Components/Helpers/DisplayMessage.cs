using Microsoft.JSInterop;
using System.Threading.Tasks;
using static BlazorMovies.Components.Helpers.IDisplayMessage;

namespace BlazorMovies.Components.Helpers
{
    public class DisplayMessage : IDisplayMessage
    {
        private readonly IJSRuntime js;

        public DisplayMessage(IJSRuntime js)
        {
            this.js = js;
        }

        public async ValueTask DoDisplayMessage(string title, string message, SweetAlertType messageType)
        {
            await js.InvokeVoidAsync("Swal.fire", title, message, messageType.ToString());
        }

        public async ValueTask DisplayError(string message)
        {
            await DoDisplayMessage("Error", message, SweetAlertType.error);
        }

        public async ValueTask DisplaySuccess(string message)
        {
            await DoDisplayMessage("Success", message, SweetAlertType.success);
        }
    }
}

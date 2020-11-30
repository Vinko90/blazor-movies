using Microsoft.JSInterop;
using System.Threading.Tasks;
using static BlazorMovies.Components.Helpers.IDisplayMessage;

namespace BlazorMovies.Components.Helpers
{
    public class DisplayMessage : IDisplayMessage
    {
        private readonly IJSRuntime js;

        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="js">Javascript runtime</param>
        public DisplayMessage(IJSRuntime js)
        {
            this.js = js;
        }

        /// <summary>
        /// Display a message with an error icon
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <returns>Operation result</returns>
        public async ValueTask DisplayError(string message)
        {
            await DoDisplayMessage("Error", message, SweetAlertType.error);
        }

        /// <summary>
        /// Display a message with a success icon
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <returns>Operation result</returns>
        public async ValueTask DisplaySuccess(string message)
        {
            await DoDisplayMessage("Success", message, SweetAlertType.success);
        }

        /// <summary>
        /// Display a message
        /// </summary>
        /// <param name="title">The modal header title</param>
        /// <param name="message">The message to be displayed</param>
        /// <param name="messageType">Define the icon to be used</param>
        /// <returns>Operation result</returns>
        public async ValueTask DoDisplayMessage(string title, string message, SweetAlertType messageType)
        {
            await js.InvokeVoidAsync("Swal.fire", title, message, messageType.ToString());
        }
    }
}

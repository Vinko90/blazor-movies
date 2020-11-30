using System.Threading.Tasks;

namespace BlazorMovies.Components.Helpers
{
    /// <summary>
    /// IDisplayMessage interface.
    /// Provide a wrapper around SweetAlert2 for displaying messages in the web client application.
    /// </summary>
    public interface IDisplayMessage
    {
        /// <summary>
        /// Display a message with an error icon
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <returns>Operation result</returns>
        ValueTask DisplayError(string message);

        /// <summary>
        /// Display a message with a success icon
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <returns>Operation result</returns>
        ValueTask DisplaySuccess(string message);

        /// <summary>
        /// Display a message
        /// </summary>
        /// <param name="title">The modal header title</param>
        /// <param name="message">The message to be displayed</param>
        /// <param name="messageType">Define the icon to be used</param>
        /// <returns>Operation result</returns>
        ValueTask DoDisplayMessage(string title, string message, SweetAlertType messageType);

        /// <summary>
        /// Icon types supported by SweetAlert2
        /// </summary>
        public enum SweetAlertType
        {
            warning,
            error,
            success,
            info,
            question
        }
    }
}

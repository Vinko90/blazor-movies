using System.Threading.Tasks;

namespace BlazorMovies.Components.Helpers
{
    public interface IDisplayMessage
    {
        ValueTask DisplayError(string message);
        ValueTask DisplaySuccess(string message);
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

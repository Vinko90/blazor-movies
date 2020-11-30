using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Helpers
{
    /// <summary>
    /// IJSRuntimeExtensionMethods class implementation.
    /// Provide support methods to the IJSRuntime.
    /// </summary>
    public static class IJSRuntimeExtensionMethods
    {
        /// <summary>
        /// Add a confirmation log
        /// </summary>
        /// <param name="js">The JSRuntime</param>
        /// <param name="message">Message to be logged</param>
        /// <returns>Operation result</returns>
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("console.log", "Requested confirmation");

            return await js.InvokeAsync<bool>("confirm", message);
        }

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="js">The JSRuntime</param>
        /// <param name="message">Message to be logged</param>
        /// <returns>Operation result</returns>
        public static async ValueTask MyFunction(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("my_function", message);
        }

        #region Support

        /// <summary>
        /// Set a value into the app local storage
        /// </summary>
        /// <param name="js">The JSRuntime</param>
        /// <param name="key">Key string value</param>
        /// <param name="content">Content value to be saved</param>
        /// <returns>Operation result</returns>
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);

        /// <summary>
        /// Get a value from the app local storage
        /// </summary>
        /// <param name="js">The JSRuntime</param>
        /// <param name="key">Key string value</param>
        /// <returns>A string with the value of the given key</returns>
        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("localStorage.getItem", key);

        /// <summary>
        /// Remove a value from the app local storage
        /// </summary>
        /// <param name="js">The JSRuntime</param>
        /// <param name="key">Key string value</param>
        /// <returns>Operation result</returns>
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("localStorage.removeItem", key);

        #endregion
    }
}

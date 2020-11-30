using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorMovies.Components.Helpers
{
    /// <summary>
    /// NavigationManagerExtensions class implementation.
    /// Provide an extension to the current app navigation manager.
    /// </summary>
    public static class NavigationManagerExtensions
    {
        /// <summary>
        /// Return the query string of the current url
        /// </summary>
        /// <param name="navMan">The navigation manager object</param>
        /// <param name="url">The current url</param>
        /// <returns>A dictionary with key values of the current url</returns>
        public static Dictionary<string, string> GetQueryStrings(this NavigationManager navMan, string url)
        {
            if (string.IsNullOrWhiteSpace(url) || !url.Contains("?") || url.Substring(url.Length - 1) == "?")
            {
                return null;
            }

            // https://example.com?key1=value1&key2=value2

            var queryStrings = url.Split(new string[] { "?" }, StringSplitOptions.None)[1];

            Dictionary<string, string> dicQueryString = queryStrings.Split('&')
                .ToDictionary(c => c.Split('=')[0],
                              c => Uri.UnescapeDataString(c.Split('=')[1]));

            return dicQueryString;
        }
    }
}

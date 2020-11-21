using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<object>> Delete(string url, bool includeToken = true);

        Task<HttpResponseWrapper<T>> Get<T>(string url, bool includeToken = true);

        Task<HttpResponseWrapper<object>> Post<T>(string url, T data, bool includeToken = true);

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, bool includeToken = true);

        Task<HttpResponseWrapper<object>> Put<T>(string url, T data, bool includeToken = true);
    }
}

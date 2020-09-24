using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tewr.Blazor.FileReader;

namespace BlazorMovies.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            //Custom Added
            builder.Services.AddTransient<IRepository, RepositoryInMemory>();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<GenreRepository>();
            builder.Services.AddScoped<PersonRepository>();
            builder.Services.AddScoped<MoviesRepository>();
            builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            await builder.Build().RunAsync();
        }
    }
}

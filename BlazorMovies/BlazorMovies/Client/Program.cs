using System;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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
            
            builder.Services.AddHttpClient<HttpClientWithToken>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<HttpClientWithoutToken>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            //Configure custom services
            ConfigureServices(builder.Services);
            
            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            //Custom Added
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IDisplayMessage, DisplayMessage>();
            
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            services.AddApiAuthorization();
        }
    }
}

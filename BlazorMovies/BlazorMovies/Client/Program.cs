using System;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Helpers.SweetAlert;
using BlazorMovies.Client.Repository;
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
            services.AddScoped<GenreRepository>();
            services.AddScoped<PersonRepository>();
            services.AddScoped<MoviesRepository>();
            services.AddScoped<RatingRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<IDisplayMessage, DisplayMessage>();
            
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            services.AddApiAuthorization();
        }
    }
}

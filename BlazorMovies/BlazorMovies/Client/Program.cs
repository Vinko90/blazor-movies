using System;
using System.Globalization;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using BlazorMovies.Components.Helpers;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorMovies.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            builder.Services.AddHttpClient<HttpClientWithToken>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<HttpClientWithoutToken>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            //Configure custom services
            ConfigureServices(builder.Services);

            var host = builder.Build();

            var js = host.Services.GetRequiredService<IJSRuntime>();
            var culture = await js.InvokeAsync<string>("getFromLocalStorage", "culture");

            CultureInfo selectedCulture;

            if (culture == null)
            {
                selectedCulture = new CultureInfo("en-US");             
            }
            else
            {
                selectedCulture = new CultureInfo(culture);
            }

            CultureInfo.DefaultThreadCurrentCulture = selectedCulture;
            CultureInfo.DefaultThreadCurrentUICulture = selectedCulture;

            await host.RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            //Custom Added
            services.AddLocalization();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IDisplayMessage, DisplayMessage>();
            
            services.AddApiAuthorization();
        }
    }
}

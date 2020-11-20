using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorMovies.Client.Auth;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
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

            //Configure custom services
            ConfigureServices(builder.Services);
            
            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //Custom Added
            //services.AddTransient<IRepository, RepositoryInMemory>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<GenreRepository>();
            services.AddScoped<PersonRepository>();
            services.AddScoped<MoviesRepository>();
            services.AddScoped<AccountsRepository>();
            services.AddScoped<RatingRepository>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
            
            services.AddAuthorizationCore();

            services.AddScoped<JWTAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>
                (
                    provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );
            services.AddScoped<ILoginService, JWTAuthenticationStateProvider>
                (
                    provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );
        }
    }
}

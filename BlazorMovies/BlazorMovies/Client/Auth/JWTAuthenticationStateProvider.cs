using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Auth
{
    public class JWTAuthenticationStateProvider : AuthenticationStateProvider, ILoginService
    {
        private readonly IJSRuntime js;
        private readonly HttpClient httpClient;
        private readonly AccountsRepository accountsRepository;
        private readonly string TOKEN_KEY = "TOKEN_KEY";
        private readonly string EXPIRATION_TOKEN_KEY = "EXPIRATION_TOKEN_KEY";

        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        #region Costructor

        public JWTAuthenticationStateProvider(IJSRuntime js, HttpClient httpClient, AccountsRepository accountsRepository)
        {
            this.js = js;
            this.httpClient = httpClient;
            this.accountsRepository = accountsRepository;
        }

        #endregion

        #region Authentication

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await js.GetFromLocalStorage(TOKEN_KEY);

            if (string.IsNullOrEmpty(token))
            {
                return Anonymous;
            }

            var expirationTimeString = await js.GetFromLocalStorage(EXPIRATION_TOKEN_KEY);

            if (DateTime.TryParse(expirationTimeString, out DateTime expirationTime))
            {
                if (IsTokenExpired(expirationTime))
                {
                    await CleanUp();
                    return Anonymous;
                }

                if (ShouldRenewToken(expirationTime))
                {
                    token = await RenewToken(token);
                }
            }

            return BuildAuthenticationState(token);
        }

        public AuthenticationState BuildAuthenticationState(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        #endregion

        #region ILoginService

        public async Task Login(UserToken token)
        {
            await js.SetInLocalStorage(TOKEN_KEY, token.Token);
            await js.SetInLocalStorage(EXPIRATION_TOKEN_KEY, token.Expiration.ToString());
            var authState = BuildAuthenticationState(token.Token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            await CleanUp();
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        public async Task TryRenewToken()
        {
            var expirationTimeString = await js.GetFromLocalStorage(EXPIRATION_TOKEN_KEY);

            if (DateTime.TryParse(expirationTimeString, out DateTime expirationTime))
            {
                if (IsTokenExpired(expirationTime))
                {
                    await Logout();
                }

                if (ShouldRenewToken(expirationTime))
                {
                    var token = await js.GetFromLocalStorage(TOKEN_KEY);
                    var newToken = await RenewToken(token);
                    var authState = BuildAuthenticationState(newToken);
                    NotifyAuthenticationStateChanged(Task.FromResult(authState));
                }
            }
        }

        #endregion

        #region Utility

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch(base64.Length % 4)
            {
                case 2: base64 += "=="; 
                    break;
                case 3: base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }

        private bool IsTokenExpired(DateTime expirationTime)
        {
            return expirationTime <= DateTime.UtcNow;
        }

        private bool ShouldRenewToken(DateTime expirationTime)
        {
            return expirationTime.Subtract(DateTime.UtcNow) < TimeSpan.FromMinutes(5);
        }

        private async Task<string> RenewToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var newToken = await accountsRepository.RenewToken();
            await js.SetInLocalStorage(TOKEN_KEY, newToken.Token);
            await js.SetInLocalStorage(EXPIRATION_TOKEN_KEY, newToken.Expiration.ToString());
            return newToken.Token;
        }

        private async Task CleanUp()
        {
            await js.RemoveItem(TOKEN_KEY);
            await js.RemoveItem(EXPIRATION_TOKEN_KEY);
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        #endregion
    }
}

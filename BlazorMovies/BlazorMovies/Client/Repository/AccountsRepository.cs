using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class AccountsRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/accounts";

        public AccountsRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<UserToken> Register(UserInfo userInfo)
        {
            var response = await httpService.Post<UserInfo, UserToken>($"{baseURL}/create", userInfo);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var response = await httpService.Post<UserInfo, UserToken>($"{baseURL}/login", userInfo);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}

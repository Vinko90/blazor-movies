using BlazorMovies.Shared.DataTransferObjects;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken token);
        
        Task Logout();
        
        Task TryRenewToken();
    }
}

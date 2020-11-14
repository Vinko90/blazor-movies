using System;

namespace BlazorMovies.Shared.DataTransferObjects
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

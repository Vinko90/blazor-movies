using System;
using System.Timers;

namespace BlazorMovies.Client.Auth
{
    public class TokenRenewer : IDisposable
    {
        private Timer timer;
        private readonly ILoginService loginService;

        public TokenRenewer(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public void Initiate()
        {
            timer = new Timer
            {
                Interval = 1000 * 60 * 4 //4 minutes - Has to be lower than ShouldRenewToken
            };
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            loginService.TryRenewToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}

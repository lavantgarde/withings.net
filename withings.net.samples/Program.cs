using System;
using System.Threading.Tasks;
using withings.net.Authentication;
using withings.net.Client;

namespace withings.net.samples
{
    class Program
    {
        private static readonly string _state = AuthUtilities.GenerateRandomDataBase64Url(32);
        private static readonly WithingsScopes _scopes = WithingsScopes.UserMetrics;

        static void Main(string[] args)
        {
            Task.Run(Do).Wait();
            Console.ReadLine();
        }

        private static void Do()
        {
            var credentials = new WithingsCredentials(Environment.GetEnvironmentVariable("debug_client_id"),
                                         Environment.GetEnvironmentVariable("debug_client_secret"),
                                         _scopes,
                                         Environment.GetEnvironmentVariable("debug_redirect_uri"),
                                         _state);

            var browserAuthentication = new BrowserAuthentication(credentials);

            var client = Task.Run(() => WithingsClient.CreateAsync(browserAuthentication, credentials)).Result;

            if (client != null)
            {
                // do something
            }
        }
    }
}

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using withings.net.Client;

namespace withings.net.Authentication
{
    public class BrowserAuthentication : IAuthentication
    {
        private readonly WithingsCredentials _credentials;

        public BrowserAuthentication(WithingsCredentials credentials)
        {
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            _credentials = credentials;
        }

        public async Task<string> GetGetAuthorizationCode() =>
            await _getAuthorizationCode();

        private async Task<string> _getAuthorizationCode()
        {
            var http = new HttpListener();
            http.Prefixes.Add(_credentials.RedirectUrl);
            http.Start();

            var authorizationRequest = $"{ApiConstants.AuthorizationCodeUrl}" +
                $"?response_type=code" +
                $"&scope={Uri.EscapeDataString(_credentials.Scopes.ConvertToString())}" +
                $"&redirect_uri={Uri.EscapeDataString(_credentials.RedirectUrl)}" +
                $"&client_id={_credentials.ClientId}" +
                $"&state={_credentials.State}";

            AuthUtilities.OpenBrowser(authorizationRequest);

            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://withings.com'></head><body>Please return to the app.</body></html>");
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;

            var responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                Console.WriteLine("HTTP server stopped.");
            });

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            if (incoming_state != _credentials.State)
            {
                throw new Exception();
            }
            return code;
        }
    }
}

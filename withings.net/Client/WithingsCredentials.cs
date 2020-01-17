namespace withings.net.Client
{
    public class WithingsCredentials
    {
        public string ClientId { get; }
        public string ClientSecret { get; }
        public WithingsScopes Scopes { get; }
        public string RedirectUrl { get; }
        public string State { get; }

        public WithingsCredentials(string clientId, string clientSecret, WithingsScopes scopes, string redirectUrl, string state)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scopes = scopes;
            RedirectUrl = redirectUrl;
            State = state;
        }
    }
}
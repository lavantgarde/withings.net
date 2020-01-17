using Newtonsoft.Json;

namespace withings.net.Authentication
{
    public class AuthorizationResponse
    {
        [JsonIgnore]
        public bool IsSuccess => !string.IsNullOrWhiteSpace(AccessToken);

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

}

using Newtonsoft.Json;

namespace withings.net.Models.Heart
{
    public class HeartResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public HeartBody HeartBody { get; set; }
    }
}

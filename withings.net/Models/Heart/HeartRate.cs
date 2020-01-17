using Newtonsoft.Json;

namespace withings.net.Models.Heart
{
    public class HeartRate
    {
        [JsonProperty("$timestamp")]
        public long Timestamp { get; set; }
    }
}

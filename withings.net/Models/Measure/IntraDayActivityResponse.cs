using Newtonsoft.Json;

namespace withings.net.Models
{
    public class IntraDayActivityResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public IntraDayActivityResponseBody Body { get; set; }
    }

    public class IntraDayActivityResponseBody
    {
        [JsonProperty("series")]
        public Series Series { get; set; }
    }
}

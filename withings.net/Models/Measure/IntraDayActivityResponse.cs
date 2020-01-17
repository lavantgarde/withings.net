using Newtonsoft.Json;
using withings.net.Models.Common;

namespace withings.net.Models
{
    public class IntraDayActivityResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public IntraDayActivityBody IntraDayActivityBody { get; set; }
    }

    public class IntraDayActivityBody
    {
        [JsonProperty("series")]
        public Series Series { get; set; }
    }
}

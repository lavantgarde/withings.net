using Newtonsoft.Json;

namespace withings.net.Models.User
{
    public class Device
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("model_id")]
        public long ModelId { get; set; }

        [JsonProperty("battery")]
        public string Battery { get; set; }

        [JsonProperty("deviceid")]
        public string Deviceid { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}

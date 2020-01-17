using Newtonsoft.Json;

namespace withings.net.Models.Common
{
    public partial class Timestamp
    {
        [JsonProperty("deviceid")]
        public long Deviceid { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("steps")]
        public long Steps { get; set; }

        [JsonProperty("elevation")]
        public long Elevation { get; set; }

        [JsonProperty("calories")]
        public long Calories { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("stroke")]
        public long Stroke { get; set; }

        [JsonProperty("pool_lap")]
        public long PoolLap { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("heart_rate")]
        public long HeartRate { get; set; }
    }
}

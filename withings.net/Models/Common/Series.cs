using Newtonsoft.Json;
using System.Collections.Generic;
using withings.net.Models.Heart;

namespace withings.net.Models.Common
{
    public class Series
    {
        [JsonProperty("$timestamp")]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("model")]
        public long Model { get; set; }

        [JsonProperty("attrib")]
        public long Attrib { get; set; }

        [JsonProperty("startdate")]
        public long Startdate { get; set; }

        [JsonProperty("enddate")]
        public long Enddate { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("modified")]
        public long Modified { get; set; }

        [JsonProperty("deviceid")]
        public string Deviceid { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, long> Data { get; set; }

        [JsonProperty("ecg")]
        public Ecg Ecg { get; set; }

        [JsonProperty("bloodpressure")]
        public Bloodpressure Bloodpressure { get; set; }

        [JsonProperty("heart_rate")]
        public long HeartRate { get; set; }
    }
}


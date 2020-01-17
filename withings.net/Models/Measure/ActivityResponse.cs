using System.Collections.Generic;
using Newtonsoft.Json;

namespace withings.net.Models.Measure
{

    public class ActivityResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public ActivityBody ActivityBody { get; set; }
    }

    public class ActivityBody
    {
        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }

        [JsonProperty("more")]
        public bool More { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}

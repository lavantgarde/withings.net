using Newtonsoft.Json;

namespace withings.net.Models.Measure
{
    public class WorkoutsResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public WorkoutsBody WorkoutsBody { get; set; }
    }
}

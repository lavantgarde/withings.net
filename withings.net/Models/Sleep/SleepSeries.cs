using Newtonsoft.Json;

namespace withings.net.Models.Sleep
{
    public class SleepSeries
    {
        [JsonProperty("startdate")]
        public string Startdate { get; set; }

        [JsonProperty("enddate")]
        public string Enddate { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("hr")]
        public Hr Hr { get; set; }

        [JsonProperty("rr")]
        public Hr Rr { get; set; }

        [JsonProperty("snoring")]
        public Hr Snoring { get; set; }
    }
}

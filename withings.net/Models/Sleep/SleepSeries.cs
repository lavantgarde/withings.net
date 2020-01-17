using Newtonsoft.Json;
using withings.net.Models.Heart;

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
        public HeartRate Hr { get; set; }

        [JsonProperty("rr")]
        public HeartRate Rr { get; set; }

        [JsonProperty("snoring")]
        public HeartRate Snoring { get; set; }
    }
}

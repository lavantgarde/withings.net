using Newtonsoft.Json;

namespace withings.net.Models.Sleep
{
    public class SleepBody
    {
        [JsonProperty("series")]
        public SleepSeries SleepSeries { get; set; }

        [JsonProperty("model")]
        public long Model { get; set; }
    }
}

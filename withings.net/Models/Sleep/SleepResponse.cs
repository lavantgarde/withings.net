using Newtonsoft.Json;

namespace withings.net.Models.Sleep
{

    public class SleepResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public SleepBody SleepBody { get; set; }
    }
}

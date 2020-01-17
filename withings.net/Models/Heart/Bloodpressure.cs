using Newtonsoft.Json;

namespace withings.net.Models.Heart
{
    public class Bloodpressure
    {
        [JsonProperty("diastole")]
        public long Diastole { get; set; }

        [JsonProperty("systole")]
        public long Systole { get; set; }
    }
}

using Newtonsoft.Json;

namespace withings.net.Models.Heart
{
    public class Ecg
    {
        [JsonProperty("signalid")]
        public long Signalid { get; set; }

        [JsonProperty("afib")]
        public long Afib { get; set; }
    }
}

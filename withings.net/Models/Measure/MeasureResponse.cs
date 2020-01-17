using Newtonsoft.Json;

namespace withings.net.Models.Measure
{
    public class MeasureResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public MeasureBody MeasureBody { get; set; }
    }
}

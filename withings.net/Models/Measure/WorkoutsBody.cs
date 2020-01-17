using System.Collections.Generic;
using Newtonsoft.Json;
using withings.net.Models.Common;

namespace withings.net.Models.Measure
{
    public class WorkoutsBody
    {
        [JsonProperty("series")]
        public List<Series> Series { get; set; }

        [JsonProperty("more")]
        public bool More { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace withings.net.Models
{
    public class MeasureBody
    {
        [JsonProperty("updatetime")]
        public string Updatetime { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("measuregrps")]
        public List<Measuregrp> Measuregrps { get; set; }

        [JsonProperty("more")]
        public bool More { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}

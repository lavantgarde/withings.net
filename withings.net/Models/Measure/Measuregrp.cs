using System.Collections.Generic;
using Newtonsoft.Json;


namespace withings.net.Models
{
    public class Measuregrp
    {
        [JsonProperty("grpid")]
        public long Grpid { get; set; }

        [JsonProperty("attrib")]
        public long Attrib { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        [JsonProperty("deviceid")]
        public string Deviceid { get; set; }

        [JsonProperty("measures")]
        public List<object> Measures { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}

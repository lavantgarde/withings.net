using Newtonsoft.Json;

namespace withings.net.Models.Measure
{
    public class Activity
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("deviceid")]
        public string Deviceid { get; set; }

        [JsonProperty("brand")]
        public long Brand { get; set; }

        [JsonProperty("is_tracker")]
        public bool IsTracker { get; set; }

        [JsonProperty("steps")]
        public long Steps { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("elevation")]
        public long Elevation { get; set; }

        [JsonProperty("soft")]
        public long Soft { get; set; }

        [JsonProperty("moderate")]
        public long Moderate { get; set; }

        [JsonProperty("intense")]
        public long Intense { get; set; }

        [JsonProperty("active")]
        public long Active { get; set; }

        [JsonProperty("calories")]
        public long Calories { get; set; }

        [JsonProperty("totalcalories")]
        public long Totalcalories { get; set; }

        [JsonProperty("hr_average")]
        public long HrAverage { get; set; }

        [JsonProperty("hr_min")]
        public long HrMin { get; set; }

        [JsonProperty("hr_max")]
        public long HrMax { get; set; }

        [JsonProperty("hr_zone_0")]
        public long HrZone0 { get; set; }

        [JsonProperty("hr_zone_1")]
        public long HrZone1 { get; set; }

        [JsonProperty("hr_zone_2")]
        public long HrZone2 { get; set; }

        [JsonProperty("hr_zone_3")]
        public long HrZone3 { get; set; }
    }
}

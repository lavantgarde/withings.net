using Newtonsoft.Json;

namespace withings.net.Models.User
{
    public class DeviceResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("body")]
        public DeviceBody DeviceBody { get; set; }
    }
}

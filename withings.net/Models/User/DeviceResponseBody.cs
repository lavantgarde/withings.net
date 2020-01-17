using System.Collections.Generic;
using Newtonsoft.Json;

namespace withings.net.Models.User
{
    public class DeviceBody
    {
        [JsonProperty("devices")]
        public List<Device> Devices { get; set; }
    }
}

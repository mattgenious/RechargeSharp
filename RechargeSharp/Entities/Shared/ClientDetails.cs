using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ClientDetails
    {
        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
    }
}
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charge
{
    public class ClientDetails
    {
        [JsonProperty("browser_ip")]
        public object BrowserIp { get; set; }

        [JsonProperty("user_agent")]
        public object UserAgent { get; set; }
    }
}
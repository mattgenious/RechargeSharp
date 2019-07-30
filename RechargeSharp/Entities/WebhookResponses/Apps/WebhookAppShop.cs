using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class WebhookAppShop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("iana_timezone")]
        public string IanaTimezone { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class WebhookChargeCreated : Charge
    {

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }
    }
}

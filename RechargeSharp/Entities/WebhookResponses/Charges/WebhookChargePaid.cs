using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class WebhookChargePaid : Charge
    {
        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }

        [JsonProperty("processed_at")]
        public DateTimeOffset ProcessedAt { get; set; }
    }
}

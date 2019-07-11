using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class SkipNextChargeRequest
    {
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }
    }
}

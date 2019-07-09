using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class DelayChargeRegenRequest
    {
        [JsonProperty("commit_update")]
        public bool CommitUpdate { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}

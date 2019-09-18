using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    public class UpdateDiscountRequest
    {
        [JsonProperty("starts_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartsAt { get; set; }

        [JsonProperty("usage_limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsageLimit { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("ends_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndsAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discount
{
    class CreateDiscountRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [JsonProperty("applies_to_product_type")]
        public string AppliesToProductType { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("duration_usage_limit")]
        public long DurationUsageLimit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("usage_limit")]
        public long UsageLimit { get; set; }

        [JsonProperty("starts_at")]
        public DateTimeOffset StartsAt { get; set; }

        [JsonProperty("ends_at")]
        public DateTimeOffset EndsAt { get; set; }
    }
}

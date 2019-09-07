using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutAppliedDiscount
    {
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Amount { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Value { get; set; }

        [JsonProperty("value_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ValueType { get; set; }

        [JsonProperty("applicable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Applicable { get; set; }

        [JsonProperty("non_applicable_reason", NullValueHandling = NullValueHandling.Ignore)]
        public object NonApplicableReason { get; set; }
    }
}

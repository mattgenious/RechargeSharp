using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutAppliedDiscount
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("value_type")]
        public string ValueType { get; set; }

        [JsonProperty("applicable")]
        public bool Applicable { get; set; }

        [JsonProperty("non_applicable_reason")]
        public object NonApplicableReason { get; set; }
    }
}

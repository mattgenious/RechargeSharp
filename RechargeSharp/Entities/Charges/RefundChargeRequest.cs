using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class RefundChargeRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}

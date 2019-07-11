using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class TotalRefundChargeRequest
    {
        [JsonProperty("full_refund")]
        public bool FullRefund { get; set; }
    }
}

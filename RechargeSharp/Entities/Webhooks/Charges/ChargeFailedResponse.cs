using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;

namespace RechargeSharp.Entities.Webhooks.Charges
{
    class ChargeFailedResponse
    {
        [JsonProperty("charge")]
        public ChargeFailed Charge { get; set; }
    }
}

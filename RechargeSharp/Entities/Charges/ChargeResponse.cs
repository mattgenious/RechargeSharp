using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeResponse
    {
        [JsonProperty("charge")]
        public Charge Charge { get; set; }
    }
}

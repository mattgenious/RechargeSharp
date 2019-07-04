using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charge
{
    class ChargeListResponse
    {
        [JsonProperty("charges")]
        public List<Charge> Charges { get; set; }
    }
}

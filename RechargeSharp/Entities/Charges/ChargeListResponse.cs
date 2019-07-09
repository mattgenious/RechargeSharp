using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    class ChargeListResponse
    {
        [JsonProperty("charges")]
        public List<Charge> Charges { get; set; }
    }
}

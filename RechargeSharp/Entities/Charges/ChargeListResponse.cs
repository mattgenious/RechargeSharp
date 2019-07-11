using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeListResponse
    {
        [JsonProperty("charges")]
        public List<Charge> Charges { get; set; }
    }
}

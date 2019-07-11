using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChangeNextChargeDateRequest
    {
        [JsonProperty("next_charge_date")]
        public DateTimeOffset NextChargeDate { get; set; }
    }
}

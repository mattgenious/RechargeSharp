using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    class ChangeNextChargeDateRequest
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}

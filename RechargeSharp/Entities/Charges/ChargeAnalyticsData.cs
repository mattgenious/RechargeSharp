using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeAnalyticsData
    {
        [JsonProperty("utm_params")] 
        public IEnumerable<object> UtmParams { get; set; }
    }
}

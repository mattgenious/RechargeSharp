using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class AnalyticsData
    {
        [JsonProperty("utm_params")] 
        public IEnumerable<UtmParams> UtmParams { get; set; }
    }
}

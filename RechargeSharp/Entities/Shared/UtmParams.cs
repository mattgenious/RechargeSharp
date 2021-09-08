using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class UtmParams
    {
        [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
        public string UtmCampaign { get; set; }

        [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
        public string UtmContent { get; set; }

        [JsonProperty("utm_data_source", NullValueHandling = NullValueHandling.Ignore)]
        public string UtmDataSource { get; set; }

        [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
        public string UtmMedium { get; set; }

        [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
        public string UtmSource { get; set; }

        [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
        public string UtmTerm { get; set; }

        [JsonProperty("utm_time_stamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UtmTimeStamp { get; set; }
    }
}
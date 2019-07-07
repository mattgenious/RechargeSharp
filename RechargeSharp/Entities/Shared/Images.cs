using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class Images
    {
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [JsonProperty("original")]
        public Uri Original { get; set; }

        [JsonProperty("small")]
        public Uri Small { get; set; }
    }
}
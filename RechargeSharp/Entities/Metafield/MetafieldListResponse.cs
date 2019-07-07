using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafield
{
    class MetafieldListResponse
    {
        [JsonProperty("metafields")]
        public Metafield[] Metafields { get; set; }
    }
}

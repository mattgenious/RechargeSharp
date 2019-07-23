using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class MetafieldResponse
    {
        [JsonProperty("metafield")]
        public Metafield Metafield { get; set; }
    }
}

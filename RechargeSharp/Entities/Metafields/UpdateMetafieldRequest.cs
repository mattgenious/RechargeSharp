using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class UpdateMetafieldRequest
    {
        [JsonProperty("metafield")]
        public UpdateMetafieldObject Metafield { get; set; }
    }
}

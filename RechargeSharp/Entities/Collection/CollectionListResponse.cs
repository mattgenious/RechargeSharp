using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collection
{
    class CollectionListResponse
    {
        [JsonProperty("products")]
        public Collection[] Products { get; set; }
    }
}

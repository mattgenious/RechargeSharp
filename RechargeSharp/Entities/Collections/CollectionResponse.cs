using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class CollectionResponse
    {
        [JsonProperty("collection")]
        public Collection Collection { get; set; }
    }
}

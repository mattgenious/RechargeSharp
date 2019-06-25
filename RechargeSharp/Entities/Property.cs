using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities
{
    public class Property
    {
        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}

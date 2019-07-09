using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class TaxLine
    {
        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

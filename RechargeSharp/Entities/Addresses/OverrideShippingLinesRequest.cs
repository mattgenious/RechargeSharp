using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class OverrideShippingLinesRequest
    {
        [JsonProperty("shipping_lines_override")]
        public List<ShippingLine> ShippingLinesOverride { get; set; }
    }
}

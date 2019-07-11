using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    class DiscountResponse
    {
        [JsonProperty("discount")]
        public Discount Discount { get; set; }
    }
}

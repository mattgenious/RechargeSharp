using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discount
{
    class DiscountListResponse
    {
        [JsonProperty("discounts")]
        public Discount[] Discounts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingRateListResponse
    {
        [JsonProperty("shipping_rates")]
        public List<ShippingRate> ShippingRates { get; set; }
    }
}

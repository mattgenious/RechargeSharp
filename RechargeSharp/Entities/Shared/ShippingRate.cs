using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    class ShippingRate
    {
        [JsonProperty("checkout")]
        public ShippingRateCheckout Checkout { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("delivery_range")]
        public object[] DeliveryRange { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_required")]
        public bool PhoneRequired { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateOrderRequest
    {
        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        public OptionalCustomer Customer { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public OptionalAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public OptionalAddress ShippingAddress { get; set; }
    }
}

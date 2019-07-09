using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutResponse
    {
        [JsonProperty("checkout")]
        public Checkout Checkout { get; set; }
    }
}

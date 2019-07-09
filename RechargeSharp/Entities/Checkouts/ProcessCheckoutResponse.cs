using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{

        public class ProcessCheckoutResponse
        {
            [JsonProperty("checkout_charge")]
            public CheckoutCharge CheckoutCharge { get; set; }
        }
}

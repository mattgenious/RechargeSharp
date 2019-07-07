using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkout
{
    class ProcessCheckoutRequest
    {
        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("payment_token")]
        public string PaymentToken { get; set; }
    }
}

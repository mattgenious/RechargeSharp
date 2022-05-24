﻿using Newtonsoft.Json;
using RechargeSharp.Utilities;

namespace RechargeSharp.Entities.PaymentMethods
{
    public class PaymentMethodResponse
    {
        [JsonProperty("payment_method")]
        public PaymentMethod? PaymentMethod { get; set; }
    }
}

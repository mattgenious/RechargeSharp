using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Checkouts
{
    public class CheckoutCompletedResponse
    {
        [JsonProperty("checkout")]
        public WebhookCheckout Checkout { get; set; }
    }
}

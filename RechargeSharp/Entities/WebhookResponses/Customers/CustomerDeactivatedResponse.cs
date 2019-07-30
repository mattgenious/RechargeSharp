using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Customers
{
    public class CustomerDeactivatedResponse
    {
        [JsonProperty("customer")]
        public WebhookCustomer Customer { get; set; }
    }
}

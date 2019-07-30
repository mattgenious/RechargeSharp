using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class WebhookApp
    {
        [JsonProperty("shop")]
        public WebhookAppShop Shop { get; set; }
    }
}

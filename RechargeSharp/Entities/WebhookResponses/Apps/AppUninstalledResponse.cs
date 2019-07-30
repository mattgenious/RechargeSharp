using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class AppUninstalledResponse
    {
        [JsonProperty("app")]
        public WebhookApp App { get; set; }
    }
}

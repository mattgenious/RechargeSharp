using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class CloneOrderRequest
    {
        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }
    }
}

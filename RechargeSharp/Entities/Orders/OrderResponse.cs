using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class OrderResponse
    {
        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}

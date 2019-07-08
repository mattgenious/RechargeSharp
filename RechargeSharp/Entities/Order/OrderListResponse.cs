using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Order
{
    class OrderListResponse
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}

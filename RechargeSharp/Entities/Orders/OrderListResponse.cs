using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    class OrderListResponse
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CustomerResponse
    {
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}

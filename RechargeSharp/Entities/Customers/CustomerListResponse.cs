using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CustomerListResponse
    {
        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }
    }
}

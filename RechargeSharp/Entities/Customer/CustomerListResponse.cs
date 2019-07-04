using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customer
{
    class CustomerListResponse
    {
        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Products
{
    public class ProductResponse
    {
        [JsonProperty("product")]
        public Product Product { get; set; }
    }
}

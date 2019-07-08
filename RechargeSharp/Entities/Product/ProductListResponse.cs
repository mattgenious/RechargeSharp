using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Product
{
    class ProductListResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}

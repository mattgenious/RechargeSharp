using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Products
{
    class ProductListResponse
    {
        [JsonProperty("products")]
        public List<Products.Product> Products { get; set; }
    }
}

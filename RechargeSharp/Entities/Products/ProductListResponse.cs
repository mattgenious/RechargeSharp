using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Products
{
    public class ProductListResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}

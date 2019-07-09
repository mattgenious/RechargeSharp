using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CustomerCountResponse
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}

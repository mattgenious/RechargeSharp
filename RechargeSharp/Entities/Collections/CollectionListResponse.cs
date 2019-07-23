using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class CollectionListResponse
    {
        [JsonProperty("products")]
        public Collection[] Products { get; set; }
    }
}

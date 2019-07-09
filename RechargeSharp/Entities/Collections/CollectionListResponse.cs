using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    class CollectionListResponse
    {
        [JsonProperty("products")]
        public Collection[] Products { get; set; }
    }
}

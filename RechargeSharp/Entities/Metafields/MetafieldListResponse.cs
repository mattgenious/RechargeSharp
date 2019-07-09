using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    class MetafieldListResponse
    {
        [JsonProperty("metafields")]
        public Metafield[] Metafields { get; set; }
    }
}

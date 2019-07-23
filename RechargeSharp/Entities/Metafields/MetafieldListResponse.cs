using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class MetafieldListResponse
    {
        [JsonProperty("metafields")]
        public Metafield[] Metafields { get; set; }
    }
}

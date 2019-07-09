using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class CountResponse
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}

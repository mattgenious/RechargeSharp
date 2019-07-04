using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class Property
    {
        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}

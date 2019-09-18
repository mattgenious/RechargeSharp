using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class Collection
    {
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

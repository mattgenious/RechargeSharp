using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class Metafield
    {
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("owner_resource")]
        public string OwnerResource { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("value_type")]
        public string ValueType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafield
{
    class CreateMetafieldRequest
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("value_type")]
        public string ValueType { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("owner_resource")]
        public string OwnerResource { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }
    }
}

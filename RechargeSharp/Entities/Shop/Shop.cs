using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shops
{
    class Shop
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("iana_timezone")]
        public string IanaTimezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("my_shopify_domain")]
        public string MyShopifyDomain { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shop_email")]
        public string ShopEmail { get; set; }

        [JsonProperty("shop_phone")]
        public string ShopPhone { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}

using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class Shop : IEquatable<Shop>
    {
        public bool Equals(Shop? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CreatedAt == other.CreatedAt && Currency == other.Currency && Domain == other.Domain && Email == other.Email && IanaTimezone == other.IanaTimezone && Id == other.Id && MyShopifyDomain == other.MyShopifyDomain && Name == other.Name && ShopEmail == other.ShopEmail && ShopPhone == other.ShopPhone && Timezone == other.Timezone && UpdatedAt == other.UpdatedAt;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Shop) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(CreatedAt);
            hash.Add(Currency);
            hash.Add(Domain);
            hash.Add(Email);
            hash.Add(IanaTimezone);
            hash.Add(Id);
            hash.Add(MyShopifyDomain);
            hash.Add(Name);
            hash.Add(ShopEmail);
            hash.Add(ShopPhone);
            hash.Add(Timezone);
            hash.Add(UpdatedAt);
            return hash.ToHashCode();
        }

        public static bool operator ==(Shop left, Shop right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Shop left, Shop right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("domain")]
        public string? Domain { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("iana_timezone")]
        public string? IanaTimezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("my_shopify_domain")]
        public string? MyShopifyDomain { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("shop_email")]
        public string? ShopEmail { get; set; }

        [JsonProperty("shop_phone")]
        public string? ShopPhone { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; }
    }
}

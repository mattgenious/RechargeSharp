using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class Shop : IEquatable<Shop>
    {
        public bool Equals(Shop other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CreatedAt == other.CreatedAt && Currency == other.Currency && Domain == other.Domain && Email == other.Email && IanaTimezone == other.IanaTimezone && Id == other.Id && MyShopifyDomain == other.MyShopifyDomain && Name == other.Name && ShopEmail == other.ShopEmail && ShopPhone == other.ShopPhone && Timezone == other.Timezone && UpdatedAt == other.UpdatedAt;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Shop) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CreatedAt != null ? CreatedAt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Domain != null ? Domain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IanaTimezone != null ? IanaTimezone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (MyShopifyDomain != null ? MyShopifyDomain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopEmail != null ? ShopEmail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopPhone != null ? ShopPhone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Timezone != null ? Timezone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UpdatedAt != null ? UpdatedAt.GetHashCode() : 0);
                return hashCode;
            }
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

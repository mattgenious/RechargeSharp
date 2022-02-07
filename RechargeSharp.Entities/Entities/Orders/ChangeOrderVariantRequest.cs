using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class ChangeOrderVariantRequest : IEquatable<ChangeOrderVariantRequest>
    {
        public bool Equals(ChangeOrderVariantRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return NewShopifyVariantId == other.NewShopifyVariantId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeOrderVariantRequest) obj);
        }

        public override int GetHashCode()
        {
            return (NewShopifyVariantId != null ? NewShopifyVariantId.GetHashCode() : 0);
        }

        public static bool operator ==(ChangeOrderVariantRequest left, ChangeOrderVariantRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeOrderVariantRequest left, ChangeOrderVariantRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("new_shopify_variant_id")]
        public string? NewShopifyVariantId { get; set; }
    }
}

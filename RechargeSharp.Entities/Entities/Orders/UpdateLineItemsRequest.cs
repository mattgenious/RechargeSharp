using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateLineItemsRequest : IEquatable<UpdateLineItemsRequest>
    {
        public bool Equals(UpdateLineItemsRequest? other)
        {
            if (other is null) return false;
            if (other.LineItems is null) return false;
            if (LineItems is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return LineItems.SequenceEqual(other.LineItems);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateLineItemsRequest) obj);
        }

        public override int GetHashCode()
        {
            return (LineItems != null ? LineItems.GetHashCode() : 0);
        }

        public static bool operator ==(UpdateLineItemsRequest left, UpdateLineItemsRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateLineItemsRequest left, UpdateLineItemsRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("line_items")]
        public IEnumerable<UpdateLineItemRequestLineItem>? LineItems { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class DelayChargeRegenRequest : IEquatable<DelayChargeRegenRequest>
    {
        public bool Equals(DelayChargeRegenRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CommitUpdate == other.CommitUpdate && Quantity == other.Quantity;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DelayChargeRegenRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CommitUpdate.GetHashCode() * 397) ^ Quantity.GetHashCode();
            }
        }

        public static bool operator ==(DelayChargeRegenRequest left, DelayChargeRegenRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DelayChargeRegenRequest left, DelayChargeRegenRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("commit_update", NullValueHandling = NullValueHandling.Ignore)]
        public bool CommitUpdate { get; set; }

        [Required]
        [Range(5, 30)]
        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}

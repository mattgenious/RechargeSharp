using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class SkipNextChargeRequestWithSingleSubscriptionId : IEquatable<SkipNextChargeRequestWithSingleSubscriptionId>, ISkipNextChargeRequest
    {
        public bool Equals(SkipNextChargeRequestWithSingleSubscriptionId? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return SubscriptionId == other.SubscriptionId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SkipNextChargeRequestWithSingleSubscriptionId) obj);
        }

        public override int GetHashCode()
        {
            return (SubscriptionId != null ? SubscriptionId.GetHashCode() : 0);
        }

        public static bool operator ==(SkipNextChargeRequestWithSingleSubscriptionId left, SkipNextChargeRequestWithSingleSubscriptionId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SkipNextChargeRequestWithSingleSubscriptionId left, SkipNextChargeRequestWithSingleSubscriptionId right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("subscription_id")]
        public string? SubscriptionId { get; set; }
    }
    public class SkipNextChargeRequestWithMultipleSubscriptionIds : IEquatable<SkipNextChargeRequestWithMultipleSubscriptionIds>, ISkipNextChargeRequest
    {
        public bool Equals(SkipNextChargeRequestWithMultipleSubscriptionIds? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return SubscriptionId == other.SubscriptionId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SkipNextChargeRequestWithMultipleSubscriptionIds)obj);
        }

        public override int GetHashCode()
        {
            return (SubscriptionId != null ? SubscriptionId.GetHashCode() : 0);
        }

        public static bool operator ==(SkipNextChargeRequestWithMultipleSubscriptionIds left, SkipNextChargeRequestWithMultipleSubscriptionIds right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SkipNextChargeRequestWithMultipleSubscriptionIds left, SkipNextChargeRequestWithMultipleSubscriptionIds right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("subscription_ids")]
        public string[]? SubscriptionId { get; set; }
    }

    public interface ISkipNextChargeRequest
    {
        
    }
}

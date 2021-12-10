using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class SubscriptionListResponse : IEquatable<SubscriptionListResponse>
    {
        public bool Equals(SubscriptionListResponse? other)
        {
            if (other is null) return false;
            if (other.Subscriptions is null) return false;
            if (Subscriptions is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Subscriptions.SequenceEqual(other.Subscriptions);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubscriptionListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscriptions != null ? Subscriptions.GetHashCode() : 0);
        }

        public static bool operator ==(SubscriptionListResponse left, SubscriptionListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubscriptionListResponse left, SubscriptionListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("subscriptions")]
        public IEnumerable<Subscription>? Subscriptions { get; set; }
    }
}

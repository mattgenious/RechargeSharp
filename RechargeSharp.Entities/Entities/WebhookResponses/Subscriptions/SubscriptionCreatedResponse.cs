using Newtonsoft.Json;
using RechargeSharp.Entities.Subscriptions;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionCreatedResponse : IEquatable<SubscriptionCreatedResponse>
    {
        public bool Equals(SubscriptionCreatedResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Subscription, other.Subscription);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubscriptionCreatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscription?.GetHashCode() ?? 0);
        }

        public static bool operator ==(SubscriptionCreatedResponse left, SubscriptionCreatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubscriptionCreatedResponse left, SubscriptionCreatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("subscription")]
        public Subscription? Subscription { get; set; }
    }
}

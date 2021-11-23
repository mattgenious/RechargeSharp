using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class SubscriptionResponse : IEquatable<SubscriptionResponse>
    {
        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        public bool Equals(SubscriptionResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Subscription, other.Subscription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubscriptionResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscription != null ? Subscription.GetHashCode() : 0);
        }

        public static bool operator ==(SubscriptionResponse left, SubscriptionResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubscriptionResponse left, SubscriptionResponse right)
        {
            return !Equals(left, right);
        }
    }
}

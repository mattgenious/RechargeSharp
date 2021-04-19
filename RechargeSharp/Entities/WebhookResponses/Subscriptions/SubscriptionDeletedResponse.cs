using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionDeletedResponse : IEquatable<SubscriptionDeletedResponse>
    {
        public bool Equals(SubscriptionDeletedResponse other)
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
            return Equals((SubscriptionDeletedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscription != null ? Subscription.GetHashCode() : 0);
        }

        public static bool operator ==(SubscriptionDeletedResponse left, SubscriptionDeletedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubscriptionDeletedResponse left, SubscriptionDeletedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("subscription")]
        public WebhookSubscriptionDeleted Subscription { get; set; }
    }
}

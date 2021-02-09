using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Subscriptions;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionCreatedResponse : IEquatable<SubscriptionCreatedResponse>
    {
        public bool Equals(SubscriptionCreatedResponse other)
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
            return Equals((SubscriptionCreatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscription != null ? Subscription.GetHashCode() : 0);
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
        public Subscription Subscription { get; set; }
    }
}

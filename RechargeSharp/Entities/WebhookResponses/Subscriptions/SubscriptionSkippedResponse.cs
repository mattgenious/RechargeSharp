using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionSkippedResponse : IEquatable<SubscriptionSkippedResponse>
    {
        public bool Equals(SubscriptionSkippedResponse other)
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
            return Equals((SubscriptionSkippedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscription != null ? Subscription.GetHashCode() : 0);
        }

        public static bool operator ==(SubscriptionSkippedResponse left, SubscriptionSkippedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubscriptionSkippedResponse left, SubscriptionSkippedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("subscription")]
        public WebhookSubscription Subscription { get; set; }
    }
}

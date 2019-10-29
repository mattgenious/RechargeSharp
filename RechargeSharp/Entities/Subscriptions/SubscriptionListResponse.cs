using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class SubscriptionListResponse : IEquatable<SubscriptionListResponse>
    {
        public bool Equals(SubscriptionListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Subscriptions.SequenceEqual(other.Subscriptions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
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
        public List<Subscription> Subscriptions { get; set; }
    }
}

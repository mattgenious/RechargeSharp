﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Subscriptions;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionActivatedResponse : IEquatable<SubscriptionActivatedResponse>
    {
        public bool Equals(SubscriptionActivatedResponse other)
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
            return Equals((SubscriptionActivatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Subscription != null ? Subscription.GetHashCode() : 0);
        }

        public static bool operator ==(SubscriptionActivatedResponse left, SubscriptionActivatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubscriptionActivatedResponse left, SubscriptionActivatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
    }
}

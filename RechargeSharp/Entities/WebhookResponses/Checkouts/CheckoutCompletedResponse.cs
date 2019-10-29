using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Checkouts
{
    public class CheckoutCompletedResponse : IEquatable<CheckoutCompletedResponse>
    {
        public bool Equals(CheckoutCompletedResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Checkout, other.Checkout);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckoutCompletedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Checkout != null ? Checkout.GetHashCode() : 0);
        }

        public static bool operator ==(CheckoutCompletedResponse left, CheckoutCompletedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutCompletedResponse left, CheckoutCompletedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("checkout")]
        public WebhookCheckout Checkout { get; set; }
    }
}

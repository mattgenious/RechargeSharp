using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutResponse : IEquatable<CheckoutResponse>
    {
        public bool Equals(CheckoutResponse other)
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
            return Equals((CheckoutResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Checkout != null ? Checkout.GetHashCode() : 0);
        }

        public static bool operator ==(CheckoutResponse left, CheckoutResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutResponse left, CheckoutResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("checkout")]
        public Checkout Checkout { get; set; }
    }
}

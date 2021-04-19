using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{

        public class ProcessCheckoutResponse : IEquatable<ProcessCheckoutResponse>
        {
            public bool Equals(ProcessCheckoutResponse other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(CheckoutCharge, other.CheckoutCharge);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ProcessCheckoutResponse) obj);
            }

            public override int GetHashCode()
            {
                return (CheckoutCharge != null ? CheckoutCharge.GetHashCode() : 0);
            }

            public static bool operator ==(ProcessCheckoutResponse left, ProcessCheckoutResponse right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ProcessCheckoutResponse left, ProcessCheckoutResponse right)
            {
                return !Equals(left, right);
            }

            [JsonProperty("checkout_charge")]
            public CheckoutCharge CheckoutCharge { get; set; }
        }
}

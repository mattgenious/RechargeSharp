using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateOrderRequest : IEquatable<UpdateOrderRequest>
    {
        public bool Equals(UpdateOrderRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Customer, other.Customer) && Equals(BillingAddress, other.BillingAddress) && Equals(ShippingAddress, other.ShippingAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateOrderRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Customer != null ? Customer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingAddress != null ? ShippingAddress.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UpdateOrderRequest left, UpdateOrderRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateOrderRequest left, UpdateOrderRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        public OptionalCustomer Customer { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public OptionalAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public OptionalAddress ShippingAddress { get; set; }
    }
}

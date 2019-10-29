using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class OrderListResponse : IEquatable<OrderListResponse>
    {
        public bool Equals(OrderListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Orders.SequenceEqual(other.Orders);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Orders != null ? Orders.GetHashCode() : 0);
        }

        public static bool operator ==(OrderListResponse left, OrderListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderListResponse left, OrderListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}

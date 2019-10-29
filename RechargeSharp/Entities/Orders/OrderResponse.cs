using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class OrderResponse : IEquatable<OrderResponse>
    {
        public bool Equals(OrderResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Order, other.Order);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Order != null ? Order.GetHashCode() : 0);
        }

        public static bool operator ==(OrderResponse left, OrderResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderResponse left, OrderResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}

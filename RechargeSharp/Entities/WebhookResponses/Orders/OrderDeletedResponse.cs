using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class OrderDeletedResponse : IEquatable<OrderDeletedResponse>
    {
        public bool Equals(OrderDeletedResponse other)
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
            return Equals((OrderDeletedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Order != null ? Order.GetHashCode() : 0);
        }

        public static bool operator ==(OrderDeletedResponse left, OrderDeletedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderDeletedResponse left, OrderDeletedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("order")]
        public WebhookOrderDeleted Order { get; set; }
    }
}

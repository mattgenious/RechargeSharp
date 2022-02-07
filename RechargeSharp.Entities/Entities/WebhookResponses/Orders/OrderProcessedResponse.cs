using Newtonsoft.Json;
using RechargeSharp.Entities.Orders;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class OrderProcessedResponse : IEquatable<OrderProcessedResponse>
    {
        public bool Equals(OrderProcessedResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Order, other.Order);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderProcessedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Order != null ? Order.GetHashCode() : 0);
        }

        public static bool operator ==(OrderProcessedResponse left, OrderProcessedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderProcessedResponse left, OrderProcessedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("order")]
        public Order? Order { get; set; }
    }
}

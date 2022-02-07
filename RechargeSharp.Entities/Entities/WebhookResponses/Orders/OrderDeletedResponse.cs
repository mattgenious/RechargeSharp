using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class OrderDeletedResponse : IEquatable<OrderDeletedResponse>
    {
        public bool Equals(OrderDeletedResponse? other)
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
            return Equals((OrderDeletedResponse) obj);
        }

        public override int GetHashCode()
        {
            return Order?.GetHashCode() ?? 0;
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
        public WebhookOrderDeleted? Order { get; set; }
    }
}

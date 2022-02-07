using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class OrderCustomer : IEquatable<OrderCustomer>
    {
        public bool Equals(OrderCustomer? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName && LastName == other.LastName && Email == other.Email;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderCustomer) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Email);
        }

        public static bool operator ==(OrderCustomer left, OrderCustomer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderCustomer left, OrderCustomer right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }
    }
}

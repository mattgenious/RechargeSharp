using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CustomerListResponse : IEquatable<CustomerListResponse>
    {
        public bool Equals(CustomerListResponse? other)
        {
            if (other is null) return false;
            if (other.Customers is null) return false;
            if (Customers is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Customers.SequenceEqual(other.Customers);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomerListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Customers != null ? Customers.GetHashCode() : 0);
        }

        public static bool operator ==(CustomerListResponse left, CustomerListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerListResponse left, CustomerListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customers")]
        public IEnumerable<Customer>? Customers { get; set; }
    }
}

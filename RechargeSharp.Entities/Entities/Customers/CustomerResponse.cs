using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CustomerResponse : IEquatable<CustomerResponse>
    {
        public bool Equals(CustomerResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Customer, other.Customer);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomerResponse) obj);
        }

        public override int GetHashCode()
        {
            return Customer?.GetHashCode() ?? 0;
        }

        public static bool operator ==(CustomerResponse left, CustomerResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerResponse left, CustomerResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customer")]
        public Customer? Customer { get; set; }
    }
}

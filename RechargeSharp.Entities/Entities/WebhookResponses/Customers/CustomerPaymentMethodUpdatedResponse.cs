using Newtonsoft.Json;
using RechargeSharp.Entities.Customers;

namespace RechargeSharp.Entities.WebhookResponses.Customers
{
    public class CustomerPaymentMethodUpdatedResponse : IEquatable<CustomerPaymentMethodUpdatedResponse>
    {
        public bool Equals(CustomerPaymentMethodUpdatedResponse? other)
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
            return Equals((CustomerPaymentMethodUpdatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return Customer?.GetHashCode() ?? 0;
        }

        public static bool operator ==(CustomerPaymentMethodUpdatedResponse left, CustomerPaymentMethodUpdatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerPaymentMethodUpdatedResponse left, CustomerPaymentMethodUpdatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customer")]
        public Customer? Customer { get; set; }
    }
}

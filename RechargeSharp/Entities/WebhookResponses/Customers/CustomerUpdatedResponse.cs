using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Customers
{
    public class CustomerUpdatedResponse : IEquatable<CustomerUpdatedResponse>
    {
        public bool Equals(CustomerUpdatedResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Customer, other.Customer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomerUpdatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Customer != null ? Customer.GetHashCode() : 0);
        }

        public static bool operator ==(CustomerUpdatedResponse left, CustomerUpdatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerUpdatedResponse left, CustomerUpdatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customer")]
        public WebhookCustomer Customer { get; set; }
    }
}

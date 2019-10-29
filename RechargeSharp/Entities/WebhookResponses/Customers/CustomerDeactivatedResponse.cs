using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Customers
{
    public class CustomerDeactivatedResponse : IEquatable<CustomerDeactivatedResponse>
    {
        public bool Equals(CustomerDeactivatedResponse other)
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
            return Equals((CustomerDeactivatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Customer != null ? Customer.GetHashCode() : 0);
        }

        public static bool operator ==(CustomerDeactivatedResponse left, CustomerDeactivatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerDeactivatedResponse left, CustomerDeactivatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customer")]
        public WebhookCustomer Customer { get; set; }
    }
}

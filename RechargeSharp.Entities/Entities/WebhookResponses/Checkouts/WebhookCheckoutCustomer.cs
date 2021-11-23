using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Checkouts
{
    public class WebhookCheckoutCustomer : IEquatable<WebhookCheckoutCustomer>
    {
        public bool Equals(WebhookCheckoutCustomer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName && LastName == other.LastName && Email == other.Email;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookCheckoutCustomer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(WebhookCheckoutCustomer left, WebhookCheckoutCustomer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookCheckoutCustomer left, WebhookCheckoutCustomer right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

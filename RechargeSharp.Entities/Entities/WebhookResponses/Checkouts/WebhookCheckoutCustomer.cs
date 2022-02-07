using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Checkouts
{
    public class WebhookCheckoutCustomer : IEquatable<WebhookCheckoutCustomer>
    {
        public bool Equals(WebhookCheckoutCustomer? other)
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
            return Equals((WebhookCheckoutCustomer) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Email);
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
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}

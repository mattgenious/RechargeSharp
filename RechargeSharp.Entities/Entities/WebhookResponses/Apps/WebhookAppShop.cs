using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class WebhookAppShop : IEquatable<WebhookAppShop>
    {
        public bool Equals(WebhookAppShop? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Email == other.Email && IanaTimezone == other.IanaTimezone && Currency == other.Currency && Timezone == other.Timezone && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookAppShop) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Email, IanaTimezone, Currency, Timezone, Id);
        }

        public static bool operator ==(WebhookAppShop left, WebhookAppShop right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookAppShop left, WebhookAppShop right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("iana_timezone")]
        public string? IanaTimezone { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
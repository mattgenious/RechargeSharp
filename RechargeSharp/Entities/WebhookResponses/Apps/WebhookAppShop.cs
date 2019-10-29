using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class WebhookAppShop : IEquatable<WebhookAppShop>
    {
        public bool Equals(WebhookAppShop other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Email == other.Email && IanaTimezone == other.IanaTimezone && Currency == other.Currency && Timezone == other.Timezone && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookAppShop) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IanaTimezone != null ? IanaTimezone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Timezone != null ? Timezone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                return hashCode;
            }
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
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("iana_timezone")]
        public string IanaTimezone { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
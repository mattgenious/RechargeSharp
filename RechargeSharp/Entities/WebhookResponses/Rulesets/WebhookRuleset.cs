using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Rulesets
{
    public class WebhookRuleset : IEquatable<WebhookRuleset>
    {
        public bool Equals(WebhookRuleset other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return UpdatedAt.Equals(other.UpdatedAt) && CreatedAt.Equals(other.CreatedAt) && Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookRuleset) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(WebhookRuleset left, WebhookRuleset right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookRuleset left, WebhookRuleset right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

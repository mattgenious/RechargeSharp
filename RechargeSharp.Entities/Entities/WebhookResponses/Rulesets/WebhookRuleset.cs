using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Rulesets
{
    public class WebhookRuleset : IEquatable<WebhookRuleset>
    {
        public bool Equals(WebhookRuleset? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return UpdatedAt.Equals(other.UpdatedAt) && CreatedAt.Equals(other.CreatedAt) && Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookRuleset) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UpdatedAt, CreatedAt, Id, Name);
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
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}

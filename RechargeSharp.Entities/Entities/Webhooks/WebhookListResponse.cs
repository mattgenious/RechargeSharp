using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class WebhookListResponse : IEquatable<WebhookListResponse>
    {
        public bool Equals(WebhookListResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Webhooks, other.Webhooks);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Webhooks != null ? Webhooks.GetHashCode() : 0);
        }

        public static bool operator ==(WebhookListResponse left, WebhookListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookListResponse left, WebhookListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("webhooks")]
        public IEnumerable<Webhook>? Webhooks { get; set; }
    }
}

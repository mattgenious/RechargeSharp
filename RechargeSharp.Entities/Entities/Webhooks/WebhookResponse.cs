using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class WebhookResponse : IEquatable<WebhookResponse>
    {
        public bool Equals(WebhookResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Webhook, other.Webhook);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookResponse) obj);
        }

        public override int GetHashCode()
        {
            return Webhook?.GetHashCode() ?? 0;
        }

        public static bool operator ==(WebhookResponse left, WebhookResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookResponse left, WebhookResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("webhook")]
        public Webhook? Webhook { get; set; }
    }
}

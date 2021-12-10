using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class WebhookApp : IEquatable<WebhookApp>
    {
        public bool Equals(WebhookApp? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Shop, other.Shop);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookApp) obj);
        }

        public override int GetHashCode()
        {
            return Shop?.GetHashCode() ?? 0;
        }

        public static bool operator ==(WebhookApp left, WebhookApp right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookApp left, WebhookApp right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("shop")]
        public WebhookAppShop? Shop { get; set; }
    }
}

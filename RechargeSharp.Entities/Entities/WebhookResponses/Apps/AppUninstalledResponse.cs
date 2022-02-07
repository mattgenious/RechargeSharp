using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Apps
{
    public class AppUninstalledResponse : IEquatable<AppUninstalledResponse>
    {
        public bool Equals(AppUninstalledResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(App, other.App);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AppUninstalledResponse) obj);
        }

        public override int GetHashCode()
        {
            return App?.GetHashCode() ?? 0;
        }

        public static bool operator ==(AppUninstalledResponse left, AppUninstalledResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AppUninstalledResponse left, AppUninstalledResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("app")]
        public WebhookApp? App { get; set; }
    }
}

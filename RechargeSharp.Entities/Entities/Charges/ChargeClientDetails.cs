using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    /// <summary>
    /// See documentation <see href="https://developer.rechargepayments.com/2021-01/charges/charge_object">https://developer.rechargepayments.com/2021-01/charges/charge_object</see>
    /// </summary>
    public class ChargeClientDetails : IEquatable<ChargeClientDetails>
    {
        public bool Equals(ChargeClientDetails? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return BrowserIp == other.BrowserIp && UserAgent == other.UserAgent;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeClientDetails) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((BrowserIp != null ? BrowserIp.GetHashCode() : 0) * 397) ^ (UserAgent != null ? UserAgent.GetHashCode() : 0);
            }
        }

        public static bool operator ==(ChargeClientDetails left, ChargeClientDetails right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeClientDetails left, ChargeClientDetails right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("browser_ip")]
        public string? BrowserIp { get; set; }

        [JsonProperty("user_agent")]
        public string? UserAgent { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class WebhookChargeCreated : Charge, IEquatable<WebhookChargeCreated>
    {
        public bool Equals(WebhookChargeCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && BrowserIp == other.BrowserIp && Nullable.Equals(ProcessedAt, other.ProcessedAt) && ProcessorName == other.ProcessorName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookChargeCreated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (BrowserIp != null ? BrowserIp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProcessedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProcessorName != null ? ProcessorName.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(WebhookChargeCreated left, WebhookChargeCreated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookChargeCreated left, WebhookChargeCreated right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }
    }
}

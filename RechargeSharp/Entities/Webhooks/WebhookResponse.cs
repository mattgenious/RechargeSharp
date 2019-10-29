using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class WebhookResponse : IEquatable<WebhookResponse>
    {
        public bool Equals(WebhookResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Webhook, other.Webhook);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Webhook != null ? Webhook.GetHashCode() : 0);
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
        public Webhook Webhook { get; set; }
    }
}

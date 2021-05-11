using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Products
{
    public class WebhookProductDeleted : IEquatable<WebhookProductDeleted>
    {
        public bool Equals(WebhookProductDeleted other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookProductDeleted) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(WebhookProductDeleted left, WebhookProductDeleted right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookProductDeleted left, WebhookProductDeleted right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}

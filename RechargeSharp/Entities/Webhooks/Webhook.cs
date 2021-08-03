using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RechargeSharp.Entities.Webhooks
{
    public class Webhook : IEquatable<Webhook>
    {
        public bool Equals(Webhook other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Address, other.Address) && Id == other.Id && Topic == other.Topic;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Webhook) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ Topic.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Webhook left, Webhook right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Webhook left, Webhook right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address")]
        public Uri Address { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("topic")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WebhookTopic? Topic { get; set; }
    }
}

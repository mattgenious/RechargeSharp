using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class CreateWebhookRequest : IEquatable<CreateWebhookRequest>
    {
        public bool Equals(CreateWebhookRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address == other.Address && Topic == other.Topic;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateWebhookRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0) * 397) ^ (Topic != null ? Topic.GetHashCode() : 0);
            }
        }

        public static bool operator ==(CreateWebhookRequest left, CreateWebhookRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateWebhookRequest left, CreateWebhookRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}

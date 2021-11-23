using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class UpdateWebhookRequest : IEquatable<UpdateWebhookRequest>
    {
        public bool Equals(UpdateWebhookRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Address, other.Address) && Topic == other.Topic;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateWebhookRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0) * 397) ^ (Topic != null ? Topic.GetHashCode() : 0);
            }
        }

        public static bool operator ==(UpdateWebhookRequest left, UpdateWebhookRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateWebhookRequest left, UpdateWebhookRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Address { get; set; }

        [JsonProperty("topic", NullValueHandling = NullValueHandling.Ignore)]
        public string Topic { get; set; }
    }
}

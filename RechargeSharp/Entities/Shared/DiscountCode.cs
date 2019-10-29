using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class DiscountCode : IEquatable<DiscountCode>
    {
        public bool Equals(DiscountCode other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Code == other.Code && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiscountCode) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Amount != null ? Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(DiscountCode left, DiscountCode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DiscountCode left, DiscountCode right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

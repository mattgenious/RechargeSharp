using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    class DiscountListResponse : IEquatable<DiscountListResponse>
    {
        public bool Equals(DiscountListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Discounts.SequenceEqual(other.Discounts);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiscountListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Discounts != null ? Discounts.GetHashCode() : 0);
        }

        public static bool operator ==(DiscountListResponse left, DiscountListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DiscountListResponse left, DiscountListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("discounts")]
        public IEnumerable<Discount> Discounts { get; set; }
    }
}

﻿using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class OverrideShippingLinesRequest : IEquatable<OverrideShippingLinesRequest>
    {
        public bool Equals(OverrideShippingLinesRequest? other)
        {
            if (other is null) return false;
            if (other.ShippingLinesOverride is null) return false;
            if (ShippingLinesOverride is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return ShippingLinesOverride.SequenceEqual(other.ShippingLinesOverride);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OverrideShippingLinesRequest) obj);
        }

        public override int GetHashCode()
        {
            return (ShippingLinesOverride != null ? ShippingLinesOverride.GetHashCode() : 0);
        }

        public static bool operator ==(OverrideShippingLinesRequest left, OverrideShippingLinesRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OverrideShippingLinesRequest left, OverrideShippingLinesRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("shipping_lines_override")]
        public IEnumerable<ShippingLine>? ShippingLinesOverride { get; set; }
    }
}

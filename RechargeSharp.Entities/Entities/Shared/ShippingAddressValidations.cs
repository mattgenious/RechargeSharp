using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingAddressValidations : IEquatable<ShippingAddressValidations>
	{
		[JsonProperty("country_is_supported", NullValueHandling = NullValueHandling.Ignore)]
		public bool? CountryIsSupported { get; set; }

		[JsonProperty("ups", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Ups { get; set; }

		public bool Equals(ShippingAddressValidations? other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(CountryIsSupported, other.CountryIsSupported) && Equals(Ups, other.Ups);
		}

		public override bool Equals(object? obj)
		{
			if (obj is null) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ShippingAddressValidations)obj);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(CountryIsSupported);
			hashCode.Add(Ups);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(ShippingAddressValidations left, ShippingAddressValidations right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ShippingAddressValidations left, ShippingAddressValidations right)
		{
			return !Equals(left, right);
		}
	}
}
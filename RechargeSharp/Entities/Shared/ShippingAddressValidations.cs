using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
	public class ShippingAddressValidations
	{
		[JsonProperty("country_is_supported", NullValueHandling = NullValueHandling.Ignore)]
		public bool? CountryIsSupported { get; set; }

		[JsonProperty("ups", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Ups { get; set; }
	}
}
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RechargeSharp.Entities.PaymentMethods
{
    public class PaymentMethodBillingAddress : Shared.Address
    {
        [Required]
        [JsonProperty("country_code")]
        public string? CountryCode { get; set; }
    }
}

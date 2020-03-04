using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Checkouts;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Checkouts
{
    public class CheckoutService : RechargeSharpService
    {
        public CheckoutService(string apiKey) : base(apiKey)
        {
        }

        public async Task<bool> CheckoutExistsAsync(string token)
        {
            var response = await GetAllowNotFoundAsync($"/checkouts/{token}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Checkout> GetCheckoutAsync(string token)
        {
            var response = await GetAsync($"/checkouts/{token}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }

        public async Task<Checkout> CreateCheckoutAsync(CreateCheckoutRequest createCheckoutRequest)
        {
            ValidateModel(createCheckoutRequest);

            var response = await PostAsJsonAsync("/checkouts", JsonConvert.SerializeObject(createCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }

        public async Task<Checkout> UpdateCheckoutAsync(string token, UpdateCheckoutRequest updateCheckoutRequest)
        {
            ValidateModel(updateCheckoutRequest);

            var response = await PutAsJsonAsync($"/checkouts/{token}", JsonConvert.SerializeObject(updateCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }

        public async Task<Checkout> UpdateCheckoutShippingLine(string token, string shippingRateHandle)
        {
            var response = await PutAsJsonAsync($"/checkouts/{token}", $"{{\"checkout\":{{\"shipping_line\":{{\"handle\":\"{shippingRateHandle}\"}}}}}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }

        public async Task<IEnumerable<ShippingRate>> RetrieveShippingRatesAsync(string token, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            ValidateModel(overrideShippingLinesRequest);

            var response = await GetAsync($"/checkouts/{token}/shipping_rates").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutShippingRateListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).ShippingRates;
        }

        public async Task<CheckoutCharge> ProcessCheckoutAsync(string token, ProcessCheckoutRequest processCheckoutRequest)
        {
            ValidateModel(processCheckoutRequest);

            var response = await PostAsJsonAsync("/checkouts/validate", JsonConvert.SerializeObject(processCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProcessCheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).CheckoutCharge;
        }
    }
}

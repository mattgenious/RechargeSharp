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
        protected CheckoutService(string apiKey) : base(apiKey)
        {
        }
        public async Task<Checkout> GetCheckoutAsync(string id)
        {
            var response = await GetAsync($"/checkouts/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }

        public async Task<Checkout> CreateCheckoutAsync(CreateCheckoutRequest createCheckoutRequest)
        {
            var response = await PostAsync("/checkouts", JsonConvert.SerializeObject(createCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }

        public async Task<Checkout> UpdateCheckoutAsync(string id, UpdateCheckoutRequest updateCheckoutRequest)
        {
            var response = await PutAsync($"/checkouts/{id}", JsonConvert.SerializeObject(updateCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Checkout;
        }
        public async Task<IEnumerable<ShippingRate>> RetrieveShippingRatesAsync(string id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            var response = await GetAsync($"/checkouts/{id}/shipping_rates").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShippingRateListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).ShippingRates;
        }

        public async Task<CheckoutCharge> ProcessCheckoutAsync(string token, ProcessCheckoutRequest processCheckoutRequest)
        {
            var response = await PostAsync("/checkouts/validate", JsonConvert.SerializeObject(processCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProcessCheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).CheckoutCharge;
        }

        public async Task DeleteCheckoutAsync(string id)
        {
            var response = await DeleteAsync($"/checkouts/{id}").ConfigureAwait(false);
        }
    }
}

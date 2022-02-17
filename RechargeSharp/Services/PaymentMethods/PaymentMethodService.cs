using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Checkouts;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Checkouts
{
    public class PaymentMethodService : RechargeSharpService
    {
        public PaymentMethodService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        private const string PaymentMethodsPath = "/payment_methods";
        private const string PaymentMethodsPathWithTrailingSlash = PaymentMethodsPath + "/";


        public async Task<bool> PaymentMethodExistsAsync(long paymentMethodId)
        {
            var response = await GetAsync($"{PaymentMethodsPathWithTrailingSlash}{paymentMethodId}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Checkout?> GetPaymentMethodAsync(long paymentMethodId)
        {
            var response = await GetAsync($"{PaymentMethodsPathWithTrailingSlash}{paymentMethodId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentMethodResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Checkout;
        }

        public async Task<Checkout?> CreateCheckoutAsync(CreateCheckoutRequest createCheckoutRequest)
        {
            ValidateModel(createCheckoutRequest);

            var response = await PostAsJsonAsync(PaymentMethodsPath, JsonConvert.SerializeObject(createCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Checkout;
        }

        public async Task<Checkout?> UpdateCheckoutAsync(string token, UpdateCheckoutRequest updateCheckoutRequest)
        {
            ValidateModel(updateCheckoutRequest);

            var response = await PutAsJsonAsync($"{PaymentMethodsPathWithTrailingSlash}{token}", JsonConvert.SerializeObject(updateCheckoutRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Checkout;
        }

        public async Task<Checkout?> UpdateCheckoutShippingLine(string token, string shippingRateHandle)
        {
            var response = await PutAsJsonAsync($"{PaymentMethodsPathWithTrailingSlash}{token}", $"{{\"checkout\":{{\"shipping_line\":{{\"handle\":\"{shippingRateHandle}\"}}}}}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Checkout;
        }

        public async Task<IEnumerable<ShippingRate>?> RetrieveShippingRatesAsync(string token, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            ValidateModel(overrideShippingLinesRequest);

            var response = await GetAsync($"{PaymentMethodsPathWithTrailingSlash}{token}/shipping_rates").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CheckoutShippingRateListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.ShippingRates;
        }

        public async Task<CheckoutCharge?> ProcessCheckoutAsync(string token, ProcessCheckoutRequest processCheckoutRequest)
        {
            ValidateModel(processCheckoutRequest);

            var response = await PostAsJsonAsync($"{PaymentMethodsPathWithTrailingSlash}{token}/charge", JsonConvert.SerializeObject(processCheckoutRequest), true).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProcessCheckoutResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.CheckoutCharge;
        }
    }
}

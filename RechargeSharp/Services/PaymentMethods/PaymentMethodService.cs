using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.PaymentMethods;

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

        public async Task<PaymentMethod?> GetPaymentMethodAsync(long paymentMethodId)
        {
            var response = await GetAsync($"{PaymentMethodsPathWithTrailingSlash}{paymentMethodId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentMethodResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false))?.PaymentMethod;
        }

        public async Task<PaymentMethod?> CreatePaymentMethodAsync(CreatePaymentMethodRequest createPaymentMethodRequest)
        {
            ValidateModel(createPaymentMethodRequest);

            var response = await PostAsJsonAsync(PaymentMethodsPath, JsonConvert.SerializeObject(createPaymentMethodRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentMethodResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false))?.PaymentMethod;
        }

        public async Task<PaymentMethod?> UpdatePaymentMethodAsync(long paymentMethodId, UpdatePaymentMethodRequest updatePaymentMethodRequest)
        {
            ValidateModel(updatePaymentMethodRequest);

            var response = await PutAsJsonAsync($"{PaymentMethodsPathWithTrailingSlash}{paymentMethodId}", JsonConvert.SerializeObject(updatePaymentMethodRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentMethodResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false))?.PaymentMethod;
        }
        public async Task<IEnumerable<PaymentMethod>?> GetPaymentMethodsAsync(int page = 1, int limit = 50, long? customerId = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += customerId != null ? $"customer_id={customerId}" : "";

            var response = await GetAsync($"{PaymentMethodsPathWithTrailingSlash}?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentMethodsResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false))?.PaymentMethods;
        }
        public async Task DeletePaymentMethodAsync(long paymentMethodId)
        {
            _ = await DeleteAsync($"{PaymentMethodsPathWithTrailingSlash}{paymentMethodId}").ConfigureAwait(false);
        }
    }
}

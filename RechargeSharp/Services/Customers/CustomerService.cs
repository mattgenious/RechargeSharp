﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Customers;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Customers
{
    public interface ICustomerService
    {
        Task<bool> CustomerExistsAsync(long id);
        Task<Customer?> GetCustomerAsync(long id);
        Task<IEnumerable<Customer>?> GetCustomersAsync(int page = 1, int limit = 50, string? email = null, string? status = null, long? shopifyCustomerId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null, string? hash = null);
        Task<IEnumerable<Customer>?> GetAllCustomersWithParamsAsync(string? email = null, string? status = null, long? shopifyCustomerId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null, string? hash = null);
        Task<long?> CountCustomersAsync(string? status = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null);
        Task<Customer?> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest);
        Task<Customer?> UpdateCustomerAsync(long id, UpdateCustomerRequest updateCustomerRequest);
        Task<Customer?> UpdateCustomerPaymentTokenAsync(long id, UpdateCustomerPaymentTokenRequest customerPaymentTokenRequest);
        Task DeleteCustomerAsync(long id);
        Task<IEnumerable<PaymentSource>?> GetCustomerPaymentSourcesAsync(long id);
    }

    public class CustomerService : RechargeSharpService, ICustomerService
    {
        public CustomerService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> CustomerExistsAsync(long id)
        {
            var response = await GetAsync($"/customers/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Customer?> GetCustomerAsync(long id)
        {
            var response = await GetAsync($"/customers/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Customer;
        }

        private async Task<IEnumerable<Customer>?> GetCustomersAsync(string queryParams)
        {
            var response = await GetAsync($"/customers?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Customers;
        }

        public Task<IEnumerable<Customer>?> GetCustomersAsync(int page = 1, int limit = 50, string? email = null, string? status = null, long? shopifyCustomerId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null, string? hash = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += email != null ? $"&email={email}" : ""; 
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : ""; 
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : ""; 
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : ""; 
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : ""; 
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : ""; 
            queryParams += hash != null ? $"&hash={hash}" : "";


            return GetCustomersAsync(queryParams);
        }

        public Task<IEnumerable<Customer>?> GetAllCustomersWithParamsAsync(string? email = null, string? status = null, long? shopifyCustomerId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null, string? hash = null)
        {
            var queryParams = "";
            queryParams += email != null ? $"&email={email}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            queryParams += hash != null ? $"&hash={hash}" : "";

            if (!string.IsNullOrEmpty(email) || shopifyCustomerId != null || !string.IsNullOrEmpty(hash))
            {
                return GetCustomersAsync(queryParams);
            }
            else
            {
                return GetAllCustomersAsync(queryParams);
            }
        }

        private async Task<IEnumerable<Customer>?> GetAllCustomersAsync(string queryParams)
        {
            var count = await CountCustomersAsync(queryParams);

            var taskList = new List<Task<IEnumerable<Customer>?>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetCustomersAsync($"page={i}&limit=250{queryParams}"));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Customer>();

            foreach (var customers in computed)
            {
                if (customers is null)
                {
                    continue;
                }
                result.AddRange(customers);
            }

            return result;
        }

        public async Task<long?> CountCustomersAsync(string? status = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return await CountCustomersAsync(queryParams);
        }

        private async Task<long?> CountCustomersAsync(string queryParams)
        {
            var response = await GetAsync($"/customers/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Count;
        }

        public async Task<Customer?> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest)
        {
            ValidateModel(createCustomerRequest);

            var response = await PostAsJsonAsync("/customers", JsonConvert.SerializeObject(createCustomerRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Customer;
        }

        public async Task<Customer?> UpdateCustomerAsync(long id, UpdateCustomerRequest updateCustomerRequest)
        {
            ValidateModel(updateCustomerRequest);

            var response = await PutAsJsonAsync($"/customers/{id}", JsonConvert.SerializeObject(updateCustomerRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Customer;
        }

        public async Task<Customer?> UpdateCustomerPaymentTokenAsync(long id, UpdateCustomerPaymentTokenRequest customerPaymentTokenRequest)
        {
            ValidateModel(customerPaymentTokenRequest);

            var response = await PutAsJsonAsync($"/customers/{id}", JsonConvert.SerializeObject(customerPaymentTokenRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Customer;
        }

        public async Task DeleteCustomerAsync(long id)
        {
            _ = await DeleteAsync($"/customers/{id}").ConfigureAwait(false);
        }

        public async Task<IEnumerable<PaymentSource>?> GetCustomerPaymentSourcesAsync(long id)
        {
            var response = await GetAsync($"/customers/{id}/payment_sources").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentSourceListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.PaymentSources;
        }
    }
}

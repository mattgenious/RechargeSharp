using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Customers;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Customers
{
    public class CustomerService : RechargeSharpService
    {
        public CustomerService(string apiKey) : base(apiKey)
        {
        }

        public async Task<CustomerResponse> GetCustomerAsync(string id)
        {
            var response = await GetAsync($"/customers/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private async Task<CustomerListResponse> GetCustomersAsync(string queryParams)
        {
            var response = await GetAsync($"/customers?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public Task<CustomerListResponse> GetCustomersAsync(int page = 1, int limit = 50, string email = null, string shopifyCustomerId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, string hash = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += email != null ? $"&email={email}" : ""; 
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : ""; 
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : ""; 
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : ""; 
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : ""; 
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : ""; 
            queryParams += hash != null ? $"&hash={hash}" : "";


            return GetCustomersAsync(queryParams);
        }

        public Task<CustomerListResponse> GetAllCustomersWithParamsAsync(string email = null, string shopifyCustomerId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, string hash = null)
        {
            var queryParams = "";
            queryParams += email != null ? $"&email={email}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            queryParams += hash != null ? $"&hash={hash}" : "";

            return GetCustomersRecAsync(queryParams, 1, new CustomerListResponse() { Customers = new List<Customer>() });
        }

        private async Task<CustomerListResponse> GetCustomersRecAsync(string queryParams, int page, CustomerListResponse accumulator)
        {
            var response = await GetAsync($"/customers?page={page}&limit=250{queryParams}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<CustomerListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            if (result.Customers.Count == 0)
            {
                return accumulator;
            }
            else
            {
                page++;
                accumulator.Customers.AddRange(result.Customers);
                return await GetCustomersRecAsync(queryParams, page+1, accumulator).ConfigureAwait(false);
            }
        }

        public async Task<CountResponse> CountCustomersAsync()
        {
            var response = await GetAsync("/customers/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest)
        {
            var response = await PostAsync("/customers", JsonConvert.SerializeObject(createCustomerRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<CustomerResponse> UpdateCustomerAsync(string id, UpdateCustomerRequest updateCustomerRequest)
        {
            var response = await PutAsync($"/customers/{id}", JsonConvert.SerializeObject(updateCustomerRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<CustomerResponse> UpdateCustomerPaymentTokenAsync(string id, UpdateCustomerPaymentTokenRequest customerPaymentTokenRequest)
        {
            var response = await PutAsync($"/customers/{id}", JsonConvert.SerializeObject(customerPaymentTokenRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CustomerResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task DeleteCustomerAsync(string id)
        {
            var response = await DeleteAsync($"/customers/{id}").ConfigureAwait(false);
        }

        public async Task<PaymentSourceListResponse> GetCustomerPaymentSourcesAsync(string id)
        {
            var response = await GetAsync($"/customers/{id}/payment_sources").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentSourceListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}

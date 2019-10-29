using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Customers;
using RechargeSharp.Entities.Orders;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Orders
{
    public class OrderService : RechargeSharpService
    {
        public OrderService(string apiKey) : base(apiKey)
        {
        }

        public async Task<Order> GetOrderAsync(long id)
        {
            var response = await GetAsync($"/orders/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Order;
        }

        private async Task<IEnumerable<Order>> GetOrdersAsync(string queryParams)
        {
            var response = await GetAsync($"/orders?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Orders;
        }

        public Task<IEnumerable<Order>> GetOrdersAsync(int page = 1, int limit = 50, long? customerId = null, long? addressId = null, long? subscriptionId = null, long? chargeId = null, string status = null, long? shopifyOrderId = null, DateTime? scheduledAtMin = null, DateTime? scheduledAtMax = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, DateTime? shippingDate = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += chargeId != null ? $"&charge_id={chargeId}" : "";
            queryParams += scheduledAtMin != null ? $"&scheduled_at_min={scheduledAtMin?.ToString("s")}" : "";
            queryParams += scheduledAtMax != null ? $"&scheduled_at_max={scheduledAtMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            queryParams += shippingDate != null ? $"&shipping_date={shippingDate?.ToString("s")}" : "";


            return GetOrdersAsync(queryParams);
        }

        public Task<IEnumerable<Order>> GetAllOrdersWithParamsAsync(long? customerId = null, long? addressId = null, long? subscriptionId = null, long? chargeId = null, string status = null, long? shopifyOrderId = null, DateTime? scheduledAtMin = null, DateTime? scheduledAtMax = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, DateTime? shippingDate = null)
        {
            var queryParams = "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += chargeId != null ? $"&charge_id={chargeId}" : "";
            queryParams += scheduledAtMin != null ? $"&scheduled_at_min={scheduledAtMin?.ToString("s")}" : "";
            queryParams += scheduledAtMax != null ? $"&scheduled_at_max={scheduledAtMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            queryParams += shippingDate != null ? $"&shipping_date={shippingDate?.ToString("s")}" : "";

            return GetAllOrdersAsync(queryParams);
        }

        private async Task<IEnumerable<Order>> GetAllOrdersAsync(string queryParams)
        {
            var count = await CountOrdersAsync();

            var taskList = new List<Task<IEnumerable<Order>>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetOrdersAsync($"page={i}&limit=250" + queryParams));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Order>();

            foreach (var charges in computed)
            {
                result.AddRange(charges);
            }

            return result;
        }

        public async Task<long> CountOrdersAsync()
        {
            var response = await GetAsync("/orders/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Count;
        }

        public async Task<Order> UpdateOrderAsync(long id, UpdateOrderRequest updateOrderRequest)
        {
            var response = await PutAsync($"/orders/{id}", JsonConvert.SerializeObject(updateOrderRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Order;
        }

        public async Task<Order> UpdateLineItemsAsync(long id, UpdateLineItemsRequest updateLineItemsRequest)
        {
            var response = await PutAsync($"/orders/{id}", JsonConvert.SerializeObject(updateLineItemsRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Order;
        }

        public async Task<Order> ChangeOrderDateAsync(long id, ChangeOrderDateRequest changeOrderDateRequest)
        {
            var response = await PostAsync($"/orders/{id}/change_date", JsonConvert.SerializeObject(changeOrderDateRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Order;
        }

        public async Task<Order> ChangeOrderVariant(long orderId, long currentShopifyVariantId, ChangeOrderVariantRequest changeOrderVariantRequest)
        {
            var response = await PostAsync($"/orders/{orderId}/update_shopify_variant/{currentShopifyVariantId}", JsonConvert.SerializeObject(changeOrderVariantRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Order;
        }
        public async Task<Order> CloneOrderAsync(long orderId, long chargeId, CloneOrderRequest cloneOrderRequest)
        {
            var response = await PostAsync($"/orders/clone_order_on_success_charge/{orderId}/charge/{chargeId}", JsonConvert.SerializeObject(cloneOrderRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Order;
        }

        public async Task DeleteOrderAsync(long id)
        {
            var response = await DeleteAsync($"/orders/{id}").ConfigureAwait(false);
        }
    }
}

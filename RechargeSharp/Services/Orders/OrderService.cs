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

        public async Task<OrderResponse> GetOrderAsync(string id)
        {
            var response = await GetAsync($"/orders/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private async Task<OrderListResponse> GetOrdersAsync(string queryParams)
        {
            var response = await GetAsync($"/orders?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public Task<OrderListResponse> GetOrdersAsync(int page = 1, int limit = 50, string customerId = null, string addressId = null, string subscriptionId = null, string chargeId = null, string status = null, string shopifyOrderId = null, DateTime? scheduledAtMin = null, DateTime? scheduledAtMax = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, DateTime? shippingDate = null)
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

        public Task<OrderListResponse> GetAllOrdersWithParamsAsync(string customerId = null, string addressId = null, string subscriptionId = null, string chargeId = null, string status = null, string shopifyOrderId = null, DateTime? scheduledAtMin = null, DateTime? scheduledAtMax = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, DateTime? shippingDate = null)
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

            return GetOrdersRecAsync(queryParams, 1, new OrderListResponse() { Orders = new List<Order>() });
        }

        private async Task<OrderListResponse> GetOrdersRecAsync(string queryParams, int page, OrderListResponse accumulator)
        {
            var response = await GetAsync($"/orders?page={page}&limit=250{queryParams}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<OrderListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            if (result.Orders.Count == 0)
            {
                return accumulator;
            }
            else
            {
                page++;
                accumulator.Orders.AddRange(result.Orders);
                return await GetOrdersRecAsync(queryParams, page, accumulator).ConfigureAwait(false);
            }
        }

        public async Task<CountResponse> CountOrdersAsync()
        {
            var response = await GetAsync("/orders/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<OrderResponse> UpdateOrderAsync(string id, UpdateOrderRequest updateOrderRequest)
        {
            var response = await PutAsync($"/orders/{id}", JsonConvert.SerializeObject(updateOrderRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<OrderResponse> UpdateLineItemsAsync(string id, UpdateLineItemsRequest updateLineItemsRequest)
        {
            var response = await PutAsync($"/orders/{id}", JsonConvert.SerializeObject(updateLineItemsRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<OrderResponse> ChangeOrderDateAsync(string id, ChangeOrderDateRequest changeOrderDateRequest)
        {
            var response = await PostAsync($"/orders/{id}/change_date", JsonConvert.SerializeObject(changeOrderDateRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<OrderResponse> ChangeOrderVariant(string orderId, string currentShopifyVariantId, ChangeOrderVariantRequest changeOrderVariantRequest)
        {
            var response = await PostAsync($"/orders/{orderId}/update_shopify_variant/{currentShopifyVariantId}", JsonConvert.SerializeObject(changeOrderVariantRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
        public async Task<OrderResponse> CloneOrderAsync(string orderId, string chargeId, CloneOrderRequest cloneOrderRequest)
        {
            var response = await PostAsync($"/orders/clone_order_on_success_charge/{orderId}/charge/{chargeId}", JsonConvert.SerializeObject(cloneOrderRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OrderResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task DeleteOrderAsync(string id)
        {
            var response = await DeleteAsync($"/orders/{id}").ConfigureAwait(false);
        }
    }
}

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RechargeSharp.v2021_11.Utilities.Json;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Entities.Customers;

public class CustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly IOptions<RechargeServiceOptions> _rechargeServiceOptions;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpClient _httpClient;

    public CustomerService(ILogger<CustomerService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
        _rechargeServiceOptions = rechargeServiceOptions;
        
        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new SnakeCaseNamingPolicy()
        };
    }
    
    public async Task<CreateCustomerTypes.Response> CreateCustomer(CreateCustomerTypes.Request request)
    {
        var requestUri = $"/customers";
        var requestAsJson = CreateJsonRequestBody(request);
        var response = await _httpClient.PostAsync(requestUri, requestAsJson);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<CreateCustomerTypes.Response>(responseStream);

        if (responseJson == null)
            throw new Exception("could not deserialize the response into JSON"); // TODO throw custom exception
        return responseJson;
    }

    public async Task<GetCustomerTypes.Response> GetCustomer(int customerId)
    {
        var requestUri = $"/customers/{customerId}";
        var response = await _httpClient.GetStreamAsync(requestUri);
        
        var responseJson = await DeserializeResponseJson<GetCustomerTypes.Response>(response);

        if (responseJson == null)
            throw new Exception("could not deserialize the response into JSON"); // TODO throw custom exception
        return responseJson;
    }
    
    public async Task<UpdateCustomerTypes.Response> UpdateCustomer(int customerId, UpdateCustomerTypes.Request request)
    {
        var requestUri = $"/customers/{customerId}";
        var requestAsJson = CreateJsonRequestBody(request);
        var response = await _httpClient.PutAsync(requestUri, requestAsJson);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<UpdateCustomerTypes.Response>(responseStream);

        if (responseJson == null)
            throw new Exception("could not deserialize the response into JSON"); // TODO throw custom exception
        return responseJson;
    }
    
    public async Task DeleteCustomer(int customerId)
    {
        var requestUri = $"/customers/{customerId}";
        var responseMessage = await _httpClient.DeleteAsync(requestUri);
    }

    public async Task<ListCustomersTypes.Response> ListCustomers(ListCustomersTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/customers{queryString.Value}";
        var response = await _httpClient.GetStreamAsync(requestUri);
        
        var responseJson = await DeserializeResponseJson<ListCustomersTypes.Response>(response);

        if (responseJson == null)
            throw new Exception("could not deserialize the response into JSON"); // TODO throw custom exception
        return responseJson;
    }
    
    public async Task<GetCustomerDeliveryScheduleTypes.Response> GetCustomerDeliverySchedule(int customerId, GetCustomerDeliveryScheduleTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/customers/{customerId}/delivery_schedule{queryString}";
        var response = await _httpClient.GetStreamAsync(requestUri);
 
        var responseJson = await DeserializeResponseJson<GetCustomerDeliveryScheduleTypes.Response>(response);

        if (responseJson == null)
            throw new Exception("could not deserialize the response into JSON"); // TODO throw custom exception
        return responseJson;
    }

    private async Task<T?> DeserializeResponseJson<T>(Stream response)
    {
        var responseJson = await JsonSerializer.DeserializeAsync<T>(response, _jsonSerializerOptions);
        return responseJson;
    }
    
    private StringContent CreateJsonRequestBody<T>(T request)
    {
        var requestJson = JsonSerializer.Serialize<T>(request, _jsonSerializerOptions);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json"); 
        return content;
    }


    public static class CreateCustomerTypes
    {
        public record Request(string Email, string FirstName, string LastName, ExternalCustomerId ExternalCustomerId);
        
        public record Response(Customer Customer);

        public record UtmParam(
            string UtmSource,
            string UtmMedium
        );

        public record AnalyticsData(
            IReadOnlyList<UtmParam> UtmParams
        );

        public record Customer(
            int Id,
            AnalyticsData AnalyticsData,
            DateTime CreatedAt,
            string Email,
            ExternalCustomerId ExternalCustomerId,
            DateTime FirstChargeProcessedAt,
            string FirstName,
            bool HasPaymentMethodInDunning,
            bool HasValidPaymentMethod,
            string Hash,
            string LastName,
            int SubscriptionsActiveCount,
            int SubscriptionsTotalCount,
            DateTime UpdatedAt
        );
    }

    public static class UpdateCustomerTypes
    {
        public record Request(string? Email, string? FirstName, string? LastName, ExternalCustomerId? ExternalCustomerId);
        
        public record UtmParam(
            string UtmSource,
            string UtmMedium
        );

        public record AnalyticsData(
            IReadOnlyList<UtmParam> UtmParams
        );

        public record ExternalCustomerId(
            string Ecommerce
        );

        public record Customer(
            int Id,
            AnalyticsData AnalyticsData,
            DateTime CreatedAt,
            string Email,
            ExternalCustomerId ExternalCustomerId,
            DateTime FirstChargeProcessedAt,
            string FirstName,
            bool HasPaymentMethodInDunning,
            bool HasValidPaymentMethod,
            string Hash,
            string LastName,
            int SubscriptionsActiveCount,
            int SubscriptionsTotalCount,
            DateTime UpdatedAt
        );

        public record Response(Customer Customer);
    }

    public static class ListCustomersTypes
    {
        public record Request(string? Email, DateTime? CreatedAtMax, DateTime? CreatedAtMin, string? Hash, int? Limit, int? Page, string? ExternalCustomerId, DateTime? UpdatedAtMax, DateTime? UpdatedAtMin);

        public record UtmParam(string UtmSource, string UtmMedium);

        public record AnalyticsData(IReadOnlyList<UtmParam> UtmParams);

        public record ExternalCustomerId(string Ecommerce);

        public record Customer(
            int Id,
            AnalyticsData AnalyticsData,
            DateTime CreatedAt,
            string Email,
            ExternalCustomerId ExternalCustomerId,
            DateTime FirstChargeProcessedAt,
            string FirstName,
            bool HasPaymentMethodInDunning,
            bool HasValidPaymentMethod,
            string Hash,
            string LastName,
            int SubscriptionsActiveCount,
            int SubscriptionsTotalCount,
            DateTime UpdatedAt
        );

        public record Response(string NextCursor, string PreviousCursor, IReadOnlyList<Customer> Customers);
    }

    public static class GetCustomerTypes
    {
        public record UtmParam(
            string UtmSource,
            string UtmMedium
        );

        public record AnalyticsData(
            IReadOnlyList<UtmParam> UtmParams
        );

        public record ExternalCustomerId(
            string Ecommerce
        );

        public record Customer(
            int Id,
            AnalyticsData AnalyticsData,
            DateTime CreatedAt,
            string Email,
            ExternalCustomerId ExternalCustomerId,
            DateTime FirstChargeProcessedAt,
            string FirstName,
            bool HasPaymentMethodInDunning,
            bool HasValidPaymentMethod,
            string Hash,
            string LastName,
            int SubscriptionsActiveCount,
            int SubscriptionsTotalCount,
            DateTime UpdatedAt
        );

        public record Response(
            Customer Customer
        );
    }

    public static class GetCustomerDeliveryScheduleTypes
    {
        public record Request(int? DeliveryCountFuture, int? FutureInterval, DateTime? DateMin, DateTime? DateMax);
        
        public record Customer(
            int Id,
            string Email,
            string FirstName,
            string LastName
        );

        public record ExternalProductId(
            string Ecommerce
        );

        public record ExternalVariantId(
            string Ecommerce
        );

        public record Images(
            string Large,
            string Medium,
            string Small,
            string Original,
            int SortOrder
        );

        public record LineItem(
            int SubscriptionId,
            ExternalProductId ExternalProductId,
            ExternalVariantId ExternalVariantId,
            Images Images,
            bool IsSkippable,
            string PlanType,
            string ProductTitle,
            IReadOnlyList<StringKeyValuePair> Properties,
            int Quantity,
            string SubtotalPrice,
            string UnitPrice,
            string VariantTitle
        );

        public record BillingAddress(
            string Address1,
            string Address2,
            string City,
            string Company,
            string CountryCode,
            string FirstName,
            string LastName,
            string Phone,
            string Province,
            string Zip
        );

        public record PaymentDetails(
            string Brand,
            string ExpMonth,
            string ExpYear,
            string Last4,
            string PaypalEmail,
            string PaypalPayerId,
            string WalletType,
            string FundingType
        );

        public record PaymentMethod(
            int Id,
            BillingAddress BillingAddress,
            PaymentDetails PaymentDetails
        );

        public record ShippingAddress(
            string Address1,
            string Address2,
            string City,
            string Company,
            string CountryCode,
            string FirstName,
            string LastName,
            string Phone,
            string Province,
            string Zip
        );

        public record Order(
            int Id,
            int AddressId,
            int ChargeId,
            IReadOnlyList<LineItem> LineItems,
            PaymentMethod PaymentMethod,
            ShippingAddress ShippingAddress
        );

        public record Delivery(
            string Date,
            IReadOnlyList<Order> Orders
        );

        public record DeliverySchedule(
            Customer Customer
            // ,
            // IReadOnlyList<Delivery> Deliveries
        );

        public record StringKeyValuePair(string Name, string Value);

        public record Response
        {
            [JsonPropertyName("deliverySchedule")] // This property is not snake cased
            public DeliverySchedule DeliverySchedule { get; init; }
        }
    }
    
    public record ExternalCustomerId(string Ecommerce);

    
}








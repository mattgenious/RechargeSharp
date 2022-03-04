using System.Text.Json;
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
        throw new NotImplementedException();
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
    
    public async Task UpdateCustomer(string customerId, UpdateCustomerTypes.Request request)
    {
        throw new NotImplementedException();
    }
    
    public async Task DeleteCustomer(string customerId)
    {
        throw new NotImplementedException();
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

    private async Task<T?> DeserializeResponseJson<T>(Stream response)
    {
        var responseJson = await JsonSerializer.DeserializeAsync<T>(response, _jsonSerializerOptions);
        return responseJson;
    }

    public async Task GetCustomerDeliverySchedule(GetCustomerDeliveryScheduleRequest request)
    {
        throw new NotImplementedException();
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
    
    public record ExternalCustomerId(string Ecommerce);

    public record GetCustomerDeliveryScheduleRequest(int? DeliveryCountFuture, int? FutureInterval, DateTime? DateMin, DateTime? DateMax);
}








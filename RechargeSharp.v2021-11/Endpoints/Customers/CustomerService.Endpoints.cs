using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Customers;

public interface ICustomerService
{
    Task<CustomerService.CreateCustomerTypes.Response> CreateCustomerAsync(CustomerService.CreateCustomerTypes.Request request);
    Task<CustomerService.GetCustomerTypes.Response?> GetCustomerAsync(long customerId);
    Task<CustomerService.UpdateCustomerTypes.Response> UpdateCustomerAsync(long customerId, CustomerService.UpdateCustomerTypes.Request request);
    Task DeleteCustomerAsync(long customerId);
    Task<CustomerService.ListCustomersTypes.Response> ListCustomersAsync(CustomerService.ListCustomersTypes.Request? request);
    Task<CustomerService.GetCustomerDeliveryScheduleTypes.Response> GetCustomerDeliveryScheduleAsync(long customerId, CustomerService.GetCustomerDeliveryScheduleTypes.Request request);
}

public partial class CustomerService : ICustomerService
{
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public CustomerService(IRechargeApiCaller rechargeApiCaller)
    {
        _rechargeApiCaller = rechargeApiCaller;
    }
    
    public async Task<CreateCustomerTypes.Response> CreateCustomerAsync(CreateCustomerTypes.Request request)
    {
        var requestUri = $"/customers";
        var responseJson = await _rechargeApiCaller.PostAsync<CreateCustomerTypes.Request, CreateCustomerTypes.Response> (request, requestUri);
        return responseJson;
    }

    public async Task<GetCustomerTypes.Response?> GetCustomerAsync(long customerId)
    {
        var requestUri = $"/customers/{customerId}";
        var responseJson = await _rechargeApiCaller.GetNullableAsync<GetCustomerTypes.Response>(requestUri);
        return responseJson;
    }
    
    public async Task<UpdateCustomerTypes.Response> UpdateCustomerAsync(long customerId,
        UpdateCustomerTypes.Request request)
    {
        var requestUri = $"/customers/{customerId}";
        var responseJson = await _rechargeApiCaller.PutAsync<UpdateCustomerTypes.Request, UpdateCustomerTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task DeleteCustomerAsync(long customerId)
    {
        var requestUri = $"/customers/{customerId}";
        await _rechargeApiCaller.DeleteAsync(requestUri);
    }

    public async Task<ListCustomersTypes.Response> ListCustomersAsync(ListCustomersTypes.Request? request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/customers{queryString.Value}";
        var responseJson = await _rechargeApiCaller.GetAsync<ListCustomersTypes.Response>(requestUri);
        return responseJson;
    }
    
    public async Task<GetCustomerDeliveryScheduleTypes.Response> GetCustomerDeliveryScheduleAsync(long customerId,
        GetCustomerDeliveryScheduleTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/customers/{customerId}/delivery_schedule{queryString}";
        var responseJson = await _rechargeApiCaller.GetAsync<GetCustomerDeliveryScheduleTypes.Response>(requestUri);
        return responseJson;
     }
}








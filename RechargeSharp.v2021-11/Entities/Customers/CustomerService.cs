namespace RechargeSharp.v2021_11.Entities.Customers;

public class CustomerService
{
    public async Task CreateCustomer(CreateCustomerRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task GetCustomer(string customerId)
    {
        throw new NotImplementedException();
    }
    
    public async Task UpdateCustomer(string customerId, UpdateCustomerRequest request)
    {
        throw new NotImplementedException();
    }
    
    public async Task DeleteCustomer(string customerId)
    {
        throw new NotImplementedException();
    }

    public async Task ListCustomers(ListCustomersRequest request)
    {
        throw new NotImplementedException();
    }
    
    public async Task GetCustomerDeliverySchedule(GetCustomerDeliveryScheduleRequest request)
    {
        throw new NotImplementedException();
    }
    
    public record CreateCustomerRequest(string email, string firstName, string lastName, ExternalCustomerId externalCustomerId);
    public record UpdateCustomerRequest(string? email, string? firstName, string? lastName, ExternalCustomerId? externalCustomerId);
    public record ExternalCustomerId(string ecommerce);
    
    public record ListCustomersRequest(string? email, DateTime? createdAtMax, DateTime? createdAtMin, string? hash, int? limit, int? page, string? externalCustomerId, DateTime? updatedAtMax, DateTime? updatedAtMin);

    public record GetCustomerDeliveryScheduleRequest(int? deliveryCountFuture, int? futureInterval, DateTime? dateMin, DateTime? dateMax);
}





using System;
using RechargeSharp.v2021_11.Endpoints.Customers;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class get_customer_delivery_schedules_200_customer_without_deliveries
{
    public static CustomerService.GetCustomerDeliveryScheduleTypes.Response CorrectlyDeserializedJson()
    {
        return new CustomerService.GetCustomerDeliveryScheduleTypes.Response(
            new CustomerService.GetCustomerDeliveryScheduleTypes.Customer(
                Id: 82940823,
                Email: "testtesttest101@test.dk",
                FirstName: "Niels",
                LastName: "Bohr"
            ),
            Deliveries: Array.Empty<CustomerService.GetCustomerDeliveryScheduleTypes.Delivery>()
        );
    }
}
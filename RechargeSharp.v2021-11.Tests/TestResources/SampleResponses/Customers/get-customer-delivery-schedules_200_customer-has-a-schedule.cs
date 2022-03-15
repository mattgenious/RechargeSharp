using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class get_customer_delivery_schedules_200_customer_has_a_schedule
{
    public static CustomerService.GetCustomerDeliveryScheduleTypes.Response CorrectlyDeserializedJson()
    {
        return new CustomerService.GetCustomerDeliveryScheduleTypes.Response()
        {
            Customer = new CustomerService.GetCustomerDeliveryScheduleTypes.Customer()
            {
                Id = 100000,
                Email = "test@test.dk",
                FirstName = "Test",
                LastName = "Testesen"
            },
            Deliveries = new[]
            {
                new CustomerService.GetCustomerDeliveryScheduleTypes.Delivery()
                {
                    Date = DateOnly.Parse("2022-03-31"),
                    Orders = new[]
                    {
                        new CustomerService.GetCustomerDeliveryScheduleTypes.Order()
                        {
                            Id = null,
                            AddressId = 1111111,
                            ChargeId = 999999999,
                            LineItems = new[]
                            {
                                new CustomerService.GetCustomerDeliveryScheduleTypes.LineItem()
                                {
                                    SubscriptionId = 3333333,
                                    ExternalProductId = new CustomerService.GetCustomerDeliveryScheduleTypes.
                                        ExternalProductId()
                                        {
                                            Ecommerce = null
                                        },
                                    ExternalVariantId = new CustomerService.GetCustomerDeliveryScheduleTypes.
                                        ExternalVariantId()
                                        {
                                            Ecommerce = null
                                        },
                                    Images = new CustomerService.GetCustomerDeliveryScheduleTypes.Images(),
                                    IsSkippable = false,
                                    PlanType = null,
                                    ProductTitle = "Test product",
                                    Properties = new[]
                                    {
                                        new CustomerService.GetCustomerDeliveryScheduleTypes.Property()
                                        {
                                            Name = "gram per dag",
                                            Value = "328"
                                        },
                                        new CustomerService.GetCustomerDeliveryScheduleTypes.Property()
                                        {
                                            Name = "kg per måned",
                                            Value = "10"
                                        }
                                    },
                                    Quantity = 2,
                                    SubtotalPrice = 0.00m,
                                    UnitPrice = 0.00m,
                                    VariantTitle = "571"
                                }
                            },
                            PaymentMethod = new CustomerService.GetCustomerDeliveryScheduleTypes.PaymentMethod()
                            {
                                Id = 1111111,
                                BillingAddress = new Address()
                                {
                                    Address1 = "Test Street 1",
                                    Address2 = null,
                                    City = "København",
                                    Company = null,
                                    Country = null,
                                    CountryCode = "DK",
                                    FirstName = "TestFirstName",
                                    LastName = "TestLastName",
                                    Phone = "11223344",
                                    Province = null,
                                    Zip = "1000"
                                },
                                PaymentDetails = new CustomerService.GetCustomerDeliveryScheduleTypes.PaymentDetails(),
                            },
                            ShippingAddress = new Address()
                            {
                                Address1 = "Test Street 1",
                                Address2 = null,
                                City = "København",
                                Company = null,
                                Country = null,
                                CountryCode = "DK",
                                FirstName = "TestFirstName",
                                LastName = "TestLastName",
                                Phone = "11223344",
                                Province = null,
                                Zip = "1000"
                            }
                        }
                    }
                },
                new CustomerService.GetCustomerDeliveryScheduleTypes.Delivery()
                {
                    Date = DateOnly.Parse("2022-04-30"),
                    Orders = new CustomerService.GetCustomerDeliveryScheduleTypes.Order[]
                    {
                        new CustomerService.GetCustomerDeliveryScheduleTypes.Order()
                        {
                            Id = null,
                            AddressId = 22222222,
                            ChargeId = null,
                            LineItems = Array.Empty<CustomerService.GetCustomerDeliveryScheduleTypes.LineItem>(),
                            PaymentMethod = new CustomerService.GetCustomerDeliveryScheduleTypes.PaymentMethod()
                            {
                                Id = 88888888,
                                BillingAddress = new Address()
                                {
                                    Address1 = "Test Street 1",
                                    Address2 = null,
                                    City = "København",
                                    Company = null,
                                    Country = null,
                                    CountryCode = "DK",
                                    FirstName = "TestFirstName",
                                    LastName = "TestLastName",
                                    Phone = "11223344",
                                    Province = null,
                                    Zip = "1000"
                                },
                                PaymentDetails =
                                    new CustomerService.GetCustomerDeliveryScheduleTypes.PaymentDetails()
                            },
                            ShippingAddress = new Address()
                            {
                                Address1 = null,
                                Address2 = null,
                                City = null,
                                Company = null,
                                Country = null,
                                CountryCode = null,
                                FirstName = null,
                                LastName = null,
                                Phone = null,
                                Province = null,
                                Zip = null
                            }
                        }
                    }
                },
                new CustomerService.GetCustomerDeliveryScheduleTypes.Delivery()
                {
                    Date = DateOnly.Parse("2022-05-30"),
                    Orders = new[]
                    {
                        new CustomerService.GetCustomerDeliveryScheduleTypes.Order()
                        {
                            Id = null,
                            AddressId = 22222222,
                            ChargeId = null,
                            LineItems =
                                Array.Empty<CustomerService.GetCustomerDeliveryScheduleTypes.LineItem>(),
                            PaymentMethod = new CustomerService.GetCustomerDeliveryScheduleTypes.PaymentMethod()
                            {
                                Id = 88888888,
                                BillingAddress = new Address()
                                {
                                    Address1 = "Test Street 1",
                                    Address2 = null,
                                    City = "København",
                                    Company = null,
                                    Country = null,
                                    CountryCode = "DK",
                                    FirstName = "TestFirstName",
                                    LastName = "TestLastName",
                                    Phone = "11223344",
                                    Province = null,
                                    Zip = "1000"
                                },
                                PaymentDetails =
                                    new CustomerService.GetCustomerDeliveryScheduleTypes.PaymentDetails()
                            },
                            ShippingAddress = new Address()
                            {
                                Address1 = null,
                                Address2 = null,
                                City = null,
                                Company = null,
                                Country = null,
                                CountryCode = null,
                                FirstName = null,
                                LastName = null,
                                Phone = null,
                                Province = null,
                                Zip = null
                            }
                        }
                    }
                }
            }
        };
    }
}
using AutoFixture.Xunit2;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Checkouts;
using RechargeSharp.Entities.Collections;
using RechargeSharp.Entities.Customers;
using RechargeSharp.Entities.Discounts;
using RechargeSharp.Entities.Metafields;
using RechargeSharp.Entities.Onetimes;
using RechargeSharp.Entities.Orders;
using RechargeSharp.Entities.Products;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Entities.Shop;
using RechargeSharp.Entities.Subscriptions;
using RechargeSharp.Entities.Tests.Utilities;
using RechargeSharp.Entities.Webhooks;
using RechargeSharp.Utilities;
using Xunit;
using Xunit.Abstractions;
using Address = RechargeSharp.Entities.Addresses.Address;

namespace RechargeSharp.Entities.Tests
{
    public class RechargeSharpSerializationTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public RechargeSharpSerializationTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void SerializeDeserializeAddressFromJsonTest()
        {
            var sut = TestDataHandler.GetTestDataAddress;

            var test = TestDataHandler.GetTestAddressString;

            var test2 = JsonConvert.DeserializeObject<Address>(test, new DateTimeOffsetJsonConverter());

            var jsonString = JsonConvert.SerializeObject(sut);

            var newAddress = JsonConvert.DeserializeObject<Address>(jsonString, new DateTimeOffsetJsonConverter());

            _testOutputHelper.WriteLine(sut.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newAddress.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(test2.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(sut.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newAddress.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(test2.UpdatedAt.ToString("O"));

            Assert.Equal(sut, newAddress);
        }

        [Fact]
        public void SerializeDeserializeAddressUTCFromJsonTest()
        {
            var sut = TestDataHandler.GetTestDataAddressUTC;

            var test = TestDataHandler.GetTestAddressUTCString;

            var test2 = JsonConvert.DeserializeObject<Address>(test, new DateTimeOffsetJsonConverter());

            var jsonString = JsonConvert.SerializeObject(sut);

            var newAddress = JsonConvert.DeserializeObject<Address>(jsonString, new DateTimeOffsetJsonConverter());

            _testOutputHelper.WriteLine(sut.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newAddress.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(test2.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(sut.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newAddress.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(test2.UpdatedAt.ToString("O"));

            Assert.Equal(sut, newAddress);
        }

        [Fact]
        public void SerializeDeserializeAddressOffsetFromJsonTest()
        {
            var sut = TestDataHandler.GetTestDataAddressOffset;

            var test = TestDataHandler.GetTestAddressOffsetString;

            var test2 = JsonConvert.DeserializeObject<Address>(test, new DateTimeOffsetJsonConverter());

            var jsonString = JsonConvert.SerializeObject(sut);

            var newAddress = JsonConvert.DeserializeObject<Address>(jsonString, new DateTimeOffsetJsonConverter());

            _testOutputHelper.WriteLine(sut.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newAddress.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(test2.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(sut.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newAddress.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(test2.UpdatedAt.ToString("O"));

            Assert.Equal(sut, newAddress);
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeAddressTest(Address sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Address>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeAddressListResponseTest(AddressListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<AddressListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeAddressResponseTest(AddressResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<AddressResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateAddressRequestResponseTest(CreateAddressRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateAddressRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOverrideShippingLinesRequestTest(OverrideShippingLinesRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OverrideShippingLinesRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateAddressRequestTest(UpdateAddressRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateAddressRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeValidateAddressErrorsTest(ValidateAddressErrors sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ValidateAddressErrors>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeValidateAddressRequestTest(ValidateAddressRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ValidateAddressRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeValidateAddressResponseTest(ValidateAddressResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ValidateAddressResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChangeNextChargeDateRequestTest(Charges.ChangeNextChargeDateRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Charges.ChangeNextChargeDateRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChargeTest(Charge sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Charge>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChargeClientDetailsTest(ChargeClientDetails sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ChargeClientDetails>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChargeDiscountCodeTest(ChargeDiscountCode sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ChargeDiscountCode>(jsonString));
        }


        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChargeResponseTest(ChargeResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            var result = JsonConvert.DeserializeObject<ChargeResponse>(jsonString);


            Assert.Equal(sut, result);
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChargeStatusTest(ChargeStatus sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ChargeStatus>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeRefundChargeRequestTest(RefundChargeRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<RefundChargeRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSkipNextChargeRequestWithMultipleSubscriptionIdsTest(SkipNextChargeRequestWithMultipleSubscriptionIds sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<SkipNextChargeRequestWithMultipleSubscriptionIds>(jsonString));
        }
        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSkipNextChargeRequestWithSingleSubscriptionIdTest(SkipNextChargeRequestWithSingleSubscriptionId sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<SkipNextChargeRequestWithSingleSubscriptionId>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeTotalRefundChargeRequestTest(TotalRefundChargeRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<TotalRefundChargeRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutTest(Checkout sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Checkout>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutAppliedDiscountTest(CheckoutAppliedDiscount sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CheckoutAppliedDiscount>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutChargeTest(CheckoutCharge sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CheckoutCharge>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutLineItemTest(CheckoutLineItem sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CheckoutLineItem>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutResponseTest(CheckoutResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CheckoutResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutShippingRateTest(CheckoutShippingRate sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CheckoutShippingRate>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCheckoutShippingRateListResponseTest(CheckoutShippingRateListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CheckoutShippingRateListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateCheckoutRequestTest(CreateCheckoutRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateCheckoutRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateCheckoutRequestCheckoutTest(CreateCheckoutRequestCheckout sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateCheckoutRequestCheckout>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateCheckoutRequestLineItemTest(CreateCheckoutRequestLineItem sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateCheckoutRequestLineItem>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeProcessCheckoutRequestTest(ProcessCheckoutRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ProcessCheckoutRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeProcessCheckoutResponseTest(ProcessCheckoutResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ProcessCheckoutResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateCheckoutRequestTest(UpdateCheckoutRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateCheckoutRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCollectionTest(Collection sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Collection>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCollectionListResponseTest(CollectionListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CollectionListResponse>(jsonString));
        }


        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCollectionResponseTest(CollectionResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CollectionResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateCustomerRequestTest(CreateCustomerRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateCustomerRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCustomerTest(Customer sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Customer>(jsonString));
        }


        [Fact]
        public void SerializeDeserializeCustomerFromJsonTest()
        {
            var sut = TestDataHandler.GetTestDataCustomer;
            _ = TestDataHandler.GetTestCustomerString;


            var jsonString = JsonConvert.SerializeObject(sut);

            var newCustomer = JsonConvert.DeserializeObject<Customer>(jsonString, new DateTimeOffsetJsonConverter());

            _testOutputHelper.WriteLine(sut.CreatedAt.ToUniversalTime().ToString("O"));
            _testOutputHelper.WriteLine(newCustomer.CreatedAt.ToUniversalTime().ToString("O"));
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine(sut.UpdatedAt.ToUniversalTime().ToString("O"));
            _testOutputHelper.WriteLine(newCustomer.UpdatedAt.ToUniversalTime().ToString("O"));
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine(sut.FirstChargeProcessedAt?.ToUniversalTime().ToString("O"));
            _testOutputHelper.WriteLine(newCustomer.FirstChargeProcessedAt?.ToUniversalTime().ToString("O"));

            Assert.Equal(sut, newCustomer);
        }


        [Fact]
        public void SerializeDeserializeCustomerFromJsonWithNullDateTimeTest()
        {
            var customerString = TestDataHandler.GetTestCustomerString;

            var newCustomer = JsonConvert.DeserializeObject<Customer>(customerString, new DateTimeOffsetJsonConverter());

            newCustomer.FirstChargeProcessedAt = null;

            var newCustomerString = JsonConvert.SerializeObject(newCustomer, new DateTimeOffsetJsonConverter());

            var newNewCustomer = JsonConvert.DeserializeObject<Customer>(newCustomerString, new DateTimeOffsetJsonConverter());

            _testOutputHelper.WriteLine(newCustomer.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newNewCustomer.CreatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newCustomer.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine(newNewCustomer.UpdatedAt.ToString("O"));
            _testOutputHelper.WriteLine((newCustomer.FirstChargeProcessedAt?.ToString("O")) ?? "null");
            _testOutputHelper.WriteLine((newNewCustomer.FirstChargeProcessedAt?.ToString("O")) ?? "null");

            Assert.Equal(newNewCustomer, newCustomer);
        }


        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCustomerListResponseTest(CustomerListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CustomerListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCustomerResponseTest(CustomerResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CustomerResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializePaymentSourceTest(PaymentSource sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<PaymentSource>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializePaymentSourceListResponseTest(PaymentSourceListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<PaymentSourceListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateCustomerPaymentTokenRequestTest(UpdateCustomerPaymentTokenRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateCustomerPaymentTokenRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateCustomerRequestTest(UpdateCustomerRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateCustomerRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeAppliesToProductTypeTest(AppliesToProductType sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<AppliesToProductType>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeAppliesToResourceTest(AppliesToResource sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<AppliesToResource>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateDiscountRequestTest(CreateDiscountRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateDiscountRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDiscountTest(Discount sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Discount>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDiscountListResponseTest(DiscountListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<DiscountListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDiscountResponseTest(DiscountResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<DiscountResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDiscountStatusTest(DiscountStatus sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<DiscountStatus>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDiscountTypeTest(DiscountType sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<DiscountType>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDurationTest(Duration sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Duration>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateDiscountRequestTest(UpdateDiscountRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateDiscountRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateMetafieldObjectTest(CreateMetafieldObject sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateMetafieldObject>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateMetafieldRequestTest(CreateMetafieldRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateMetafieldRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeMetafieldTest(Metafield sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Metafield>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeMetafieldListResponseTest(MetafieldListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<MetafieldListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeMetafieldResponseTest(MetafieldResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<MetafieldResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOwnerResourceTest(OwnerResource sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OwnerResource>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateMetafieldObjectTest(UpdateMetafieldObject sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateMetafieldObject>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateMetafieldRequestTest(UpdateMetafieldRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateMetafieldRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateOnetimeRequestTest(CreateOnetimeRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateOnetimeRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOnetimeTest(Onetime sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Onetime>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOnetimeListResponseTest(OnetimeListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OnetimeListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOnetimeResponseTest(OnetimeResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OnetimeResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateOnetimeRequestTest(UpdateOnetimeRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateOnetimeRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChangeOrderDateRequestTest(ChangeOrderDateRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ChangeOrderDateRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChangeOrderVariantRequestTest(ChangeOrderVariantRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ChangeOrderVariantRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCloneOrderRequestTest(CloneOrderRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CloneOrderRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOrderTest(Order sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Order>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOrderAddressTest(OrderAddress sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OrderAddress>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOrderCustomerTest(OrderCustomer sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OrderCustomer>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOrderListResponseTest(OrderListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OrderListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOrderResponseTest(OrderResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OrderResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeOrderStatusTest(OrderStatus sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<OrderStatus>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateLineItemRequestLineItemTest(UpdateLineItemRequestLineItem sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateLineItemRequestLineItem>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateLineItemsRequestTest(UpdateLineItemsRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateLineItemsRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateOrderRequestTest(UpdateOrderRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateOrderRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeProductTest(Product sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Product>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeProductListResponseTest(ProductListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ProductListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeProductResponseTest(ProductResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ProductResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeProductSubscriptionDefaultsTest(ProductSubscriptionDefaults sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ProductSubscriptionDefaults>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeStorefrontPurchaseOptionsTest(StorefrontPurchaseOptions sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<StorefrontPurchaseOptions>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSharedAddressTest(Shared.Address sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Shared.Address>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCountResponseTest(CountResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CountResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeImagesTest(Images sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Images>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSharedLineItemTest(LineItem sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<LineItem>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShippingAddressValidationsTest(ShippingAddressValidations sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ShippingAddressValidations>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShippingLineTest(ShippingLine sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ShippingLine>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShippingRateTest(ShippingRate sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ShippingRate>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeTaxLineTest(TaxLine sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<TaxLine>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShippingCountriesResponseTest(ShippingCountriesResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ShippingCountriesResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShippingCountryTest(ShippingCountry sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ShippingCountry>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShopTest(Shop.Shop sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Shop.Shop>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeShopResponseTest(ShopResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ShopResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCancelSubscriptionRequestTest(CancelSubscriptionRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CancelSubscriptionRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeChangeAddressRequestTest(ChangeAddressRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<ChangeAddressRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateSubscriptionRequestTest(CreateSubscriptionRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateSubscriptionRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeDelayChargeRegenRequestTest(DelayChargeRegenRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<DelayChargeRegenRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSubscriptionTest(Subscription sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Subscription>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSubscriptionListResponseTest(SubscriptionListResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<SubscriptionListResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSubscriptionResponseTest(SubscriptionResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<SubscriptionResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeSubscriptionStatusTest(SubscriptionStatus sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<SubscriptionStatus>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateSubscriptionRequestTest(UpdateSubscriptionRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateSubscriptionRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeCreateWebhookRequestTest(CreateWebhookRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<CreateWebhookRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeUpdateWebhookRequestTest(UpdateWebhookRequest sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<UpdateWebhookRequest>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeWebhookTest(Webhook sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<Webhook>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeWebhookResponseTest(WebhookResponse sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<WebhookResponse>(jsonString));
        }

        [Theory]
        [InlineAutoData]
        public void SerializeDeserializeWebhookTopicTest(WebhookTopic sut)
        {
            var jsonString = JsonConvert.SerializeObject(sut);

            Assert.Equal(sut, JsonConvert.DeserializeObject<WebhookTopic>(jsonString));
        }


    }
}

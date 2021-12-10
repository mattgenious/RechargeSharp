using RechargeSharp.Entities.Addresses;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RechargeSharp.Entities.Tests.Entities.Addresses
{
    public class AddressListResponseTests
    {
        /// <summary>
        /// Ensure that default equals behavior is now like SequenceEquals
        /// </summary>
        [Fact]
        public void TestEqualsBehavior()
        {
            var testName = "John";
            var addressListResponse1 = new AddressListResponse()
            {
                Addresses = new List<Address>()
                {
                    new Address() { FirstName = testName },
                    new Address() { FirstName = testName + "2" }
                }
            };

            var addressListResponse2 = new AddressListResponse()
            {
                Addresses = new List<Address>()
                {
                    new Address() { FirstName = testName },
                    new Address() { FirstName = testName + "2" }
                }
            };

            // ruin order
            addressListResponse1.Addresses = addressListResponse1.Addresses.OrderByDescending(x => x.FirstName);

            // fix order
            addressListResponse1.Addresses = addressListResponse1.Addresses.OrderBy(x => x.FirstName);

            // They are equal
            Assert.Equal(addressListResponse1, addressListResponse2);
            Assert.True(addressListResponse1.Equals(addressListResponse2));

            // They are not the same object
            Assert.False(ReferenceEquals(addressListResponse1, addressListResponse2));
        }
    }
}

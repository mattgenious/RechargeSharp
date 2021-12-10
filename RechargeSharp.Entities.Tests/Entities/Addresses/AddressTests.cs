using RechargeSharp.Entities.Shared;
using System.Collections.Generic;
using Xunit;

namespace RechargeSharp.Entities.Tests.Entities.Addresses
{
    public class AddressTests
    {
        /// <summary>
        /// Ensure that default equals behavior is now like SequenceEquals
        /// </summary>
        [Fact]
        public void TestEqualsBehavior()
        {
            var testName = "John";

            var address1 = new RechargeSharp.Entities.Addresses.Address() { FirstName = testName, NoteAttributes = new List<Property>() };
            var address2 = new RechargeSharp.Entities.Addresses.Address() { FirstName = testName, NoteAttributes = new List<Property>() };

            // They are equal
            Assert.Equal(address1, address2);
            Assert.True(address1.Equals(address2));

            // They are not the same object
            Assert.False(ReferenceEquals(address1, address2));
        }
    }
}

using Newtonsoft.Json;
using RechargeSharp.Entities.Subscriptions;
using System;
using Xunit;

namespace RechargeSharp.Entities.Tests
{
    public class RechargeSharpEnumSerializationTests
    {
        [Fact]
        public void SerializeDeserializeSubscriptionStatusTest()
        {
            var enumVal = SubscriptionStatus.Active;

            var stringVal = enumVal.ToString();
            var result = (SubscriptionStatus)Enum.Parse(typeof(SubscriptionStatus), stringVal);

            Assert.Equal(enumVal, result);
        }

        [Fact]
        public void NewtonsoftSerializeDeserializeSubscriptionStatusTest()
        {
            var enumVal = SubscriptionStatus.Active;

            var stringVal = JsonConvert.SerializeObject(enumVal);

            Assert.Equal("\"ACTIVE\"", stringVal);

            var result = JsonConvert.DeserializeObject<SubscriptionStatus>(stringVal);

            Assert.Equal(enumVal, result);
        }
    }
}

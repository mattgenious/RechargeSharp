using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Utilities;
using System.IO;

namespace RechargeSharpTests.Utilities
{
    internal class TestDataHandler
    {
        public static Address GetTestDataAddress => JsonConvert.DeserializeObject<Address>(GetTestAddressString, new DateTimeJsonConverter());
        public static Address GetTestDataAddressUTC => JsonConvert.DeserializeObject<Address>(GetTestAddressUTCString, new DateTimeJsonConverter());
        public static Address GetTestDataAddressOffset => JsonConvert.DeserializeObject<Address>(GetTestAddressOffsetString, new DateTimeJsonConverter());

        public static string GetTestAddressString => File.ReadAllText(TestDataPaths.Address);
        public static string GetTestAddressOffsetString => File.ReadAllText(TestDataPaths.AddressOffset);
        public static string GetTestAddressUTCString => File.ReadAllText(TestDataPaths.AddressUTC);
    }
}

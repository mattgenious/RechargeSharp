using System.IO;

namespace RechargeSharp.Entities.Tests.Utilities
{
    internal class TestDataPaths
    {
        static string BasePath => Path.Join(Directory.GetCurrentDirectory(), "TestData");
        public static string Customer => Path.Join(BasePath, "Customer.json");
        public static string Address => Path.Join(BasePath, "Address.json");
        public static string AddressUTC => Path.Join(BasePath, "AddressUTC.json");
        public static string AddressOffset => Path.Join(BasePath, "AddressOffset.json");
        public static string Product => Path.Join(BasePath, "Product.json");
    }
}

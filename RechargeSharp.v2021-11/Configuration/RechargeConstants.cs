namespace RechargeSharp.v2021_11.Configuration;

public static class RechargeConstants
{
    public const string ApiUrl = "https://api.rechargeapps.com";

    public static class Headers
    {
        public static class Keys
        {
            public const string ApiVersion = "X-Recharge-Version";
            public const string ApiKey = "X-Recharge-Access-Token";
        }

        public static class Values
        {
            public const string Version2021_11 = "2021-11";
        }
    }
}
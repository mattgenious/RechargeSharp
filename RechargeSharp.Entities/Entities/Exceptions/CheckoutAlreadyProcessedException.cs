namespace RechargeSharp.Entities.Exceptions
{
    /// <summary>
    /// Signifies that the checkout has already been processed
    /// </summary>
    public class CheckoutAlreadyProcessedException : Exception
    {
        public CheckoutAlreadyProcessedException(string message) : base(message)
        {
        }
    }
}
namespace RechargeSharp.Entities.Exceptions
{
    /// <summary>
    /// Signifies that a problem occurred with the payment method
    /// </summary>
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message)
        {
        }
    }
}
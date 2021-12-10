namespace RechargeSharp.Entities.Exceptions
{
    /// <summary>
    /// Signifies that Strong Customer Authorization is required to proceed
    /// </summary>
    public class ScaException : Exception
    {
        public ScaException(string message) : base(message)
        {
        }
    }
}
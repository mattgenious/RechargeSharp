namespace RechargeSharp.Entities.Exceptions
{
    /// <summary>
    /// Signifies that the requested resource was not found
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
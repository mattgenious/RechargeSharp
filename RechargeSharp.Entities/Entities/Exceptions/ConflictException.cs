namespace RechargeSharp.Entities.Exceptions
{
    /// <summary>
    /// Signifies that a call to that API route is already in progress
    /// </summary>
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
using System;

namespace RechargeSharp.Entities.Exceptions
{
    /// <summary>
    /// Signifies that an unspecified transient error occurred and it is advised to attempt processing again at a later time
    /// </summary>
    public class TransientErrorException : Exception
    {
        public TransientErrorException(string message) : base(message)
        {
        }
    }
}
using System;

namespace DMTest.Domain.Exceptions
{
    public class DMTestAuthException : Exception
    {
        public DMTestAuthException()
        {
        }

        public DMTestAuthException(string message)
            : base(message)
        {
        }

        public DMTestAuthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

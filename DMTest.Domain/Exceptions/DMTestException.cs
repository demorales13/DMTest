using System;

namespace DMTest.Domain.Exceptions
{
    public class DMTestException : Exception
    {
        public DMTestException()
        {
        }

        public DMTestException(string message)
            : base(message)
        {
        }

        public DMTestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

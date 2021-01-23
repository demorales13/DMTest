using System;

namespace DMTest.Domain.Exceptions
{
    public class TestAuthException : Exception
    {
        public TestAuthException()
        {
        }

        public TestAuthException(string message)
            : base(message)
        {
        }

        public TestAuthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

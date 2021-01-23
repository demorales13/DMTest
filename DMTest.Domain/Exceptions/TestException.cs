using System;

namespace DMTest.Domain.Exceptions
{
    public class TestException : Exception
    {
        public TestException()
        {
        }

        public TestException(string message)
            : base(message)
        {
        }

        public TestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

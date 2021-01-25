using System;

namespace DMTest.Domain.Exceptions
{
    public class DMTestNotFoundException : Exception
    {
        public DMTestNotFoundException()
        {
        }

        public DMTestNotFoundException(string message)
            : base(message)
        {
        }

        public DMTestNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

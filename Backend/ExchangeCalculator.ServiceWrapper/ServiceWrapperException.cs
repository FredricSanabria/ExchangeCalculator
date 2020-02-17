using System;

namespace ExchangeCalculator.ServiceWrapper
{
    public class ServiceWrapperException : Exception
    {
        public ServiceWrapperException()
        {
        }

        public ServiceWrapperException(string message) : base(message)
        {
        }

        public ServiceWrapperException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

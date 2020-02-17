using System;

namespace ExchangeCalculator.ServiceWrapper
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException()
        {
        }

        public InvalidDateException(string message) : base(message)
        {
        }

        public InvalidDateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

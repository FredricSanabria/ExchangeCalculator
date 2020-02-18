using System;

namespace ExchangeCalculator.WebApi
{
    public class ExchangeCalculatorException : Exception
    {
        public ExchangeCalculatorException()
        {
        }

        public ExchangeCalculatorException(string message) : base(message)
        {
        }

        public ExchangeCalculatorException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

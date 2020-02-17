using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Application.UseCases;
using ExchangeCalculator.ServiceWrapper.Repositories;
using Xunit;

namespace ExchangeCalculator.Application.Tests.UseCaseTests
{
    public class GetCurrenciesTests
    {
        private readonly GetCurrencies _useCase;

        public GetCurrenciesTests()
        {
            _useCase = new GetCurrencies(new SweaMockRepository());
        }

        [Fact]
        public void CanGetCurrencies()
        {
            const int expectedCount = 20;

            var currencies = _useCase.Execute();

            Assert.Equal(expectedCount, currencies.Count);
        }

        [Fact]
        public void CanGetCurrenciesIncludingObsolete()
        {
            const int expectedCount = 49;
            const bool includeObsolete = true;

            var currencies = _useCase.Execute(includeObsolete);

            Assert.Equal(expectedCount, currencies.Count);
        }
    }
}

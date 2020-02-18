using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.ServiceWrapper.Repositories;
using System;
using Xunit;

namespace ExchangeCalculator.ServiceWrapper.Tests
{
    public class SweaRepositoryTests
    {
        private readonly ISweaRepository _repository;

        public SweaRepositoryTests()
        {
            _repository = new SweaMockRepository();
        }

        [Fact]
        public void CanGetCurrencies()
        {
            const int expectedCount = 29;

            var currencies = _repository.GetCurrencies();

            Assert.Equal(expectedCount, currencies.Count);
        }

        [Fact]
        public void CanGetCurrenciesIncludingObsolete()
        {
            const int expectedCount = 49;
            const bool includeObsolete = true;

            var currencies = _repository.GetCurrencies(includeObsolete);

            Assert.Equal(expectedCount, currencies.Count);
        }

        [Fact]
        public async void CanGetConvertedAmountAsync1()
        {
            const decimal originalAmount = 150M;
            const decimal expectedSum = 1.2038M * originalAmount;
            const string fromCurrency = "SEKGBPPMI";
            const string toCurrency = "SEKEURPMI";
            var conversionDate = Convert.ToDateTime("2020-02-14");

            var conversionRate = await _repository.GetConvertedAmountAsync(fromCurrency, originalAmount, toCurrency, conversionDate);

            Assert.Equal(expectedSum, conversionRate);
        }

        [Fact]
        public async void CanGetConvertedAmountAsync2()
        {
            const decimal originalAmount = 275M;
            const decimal expectedSum = 9.2413M * originalAmount;
            const string fromCurrency = "SEKUSDPMI";
            const string toCurrency = "SEKNOKPMI";
            var conversionDate = Convert.ToDateTime("2020-02-17");

            var conversionRate = await _repository.GetConvertedAmountAsync(fromCurrency, originalAmount, toCurrency, conversionDate);

            Assert.Equal(expectedSum, conversionRate);
        }

        [Fact]
        public async void CanGetConvertedAmountAsync3()
        {
            const decimal originalAmount = 150M;
            const decimal expectedSum = 1.94M * originalAmount;
            const string fromCurrency = "SEKGBPPMI";
            const string toCurrency = "SEKAUDPMI";
            var conversionDate = Convert.ToDateTime("2020-02-14");

            var convertedSum = await _repository.GetConvertedAmountAsync(fromCurrency, originalAmount, toCurrency, conversionDate);

            Assert.Equal(expectedSum, convertedSum);
        }

        [Fact]
        public async void CanGetConvertedAmountAsync4()
        {
            const decimal originalAmount = 275M;
            const decimal expectedSum = 1.4869M * originalAmount;
            const string fromCurrency = "SEKUSDPMI";
            const string toCurrency = "SEKAUDPMI";
            var conversionDate = Convert.ToDateTime("2020-02-17");

            var convertedSum = await _repository.GetConvertedAmountAsync(fromCurrency, originalAmount, toCurrency, conversionDate);

            Assert.Equal(expectedSum, convertedSum);
        }

        [Fact]
        public async void CanRaiseInvalidDateException1()
        {
            const decimal originalAmount = 150M;
            const string fromCurrency = "SEKGBPPMI";
            const string toCurrency = "SEKEURPMI";
            var saturday = Convert.ToDateTime("2020-02-15");

            await Assert.ThrowsAsync<InvalidDateException>(() => _repository.GetConvertedAmountAsync(fromCurrency, originalAmount, toCurrency, saturday));
        }

        [Fact]
        public async void CanRaiseInvalidDateException2()
        {
            const decimal originalAmount = 150M;
            const string fromCurrency = "SEKGBPPMI";
            const string toCurrency = "SEKEURPMI";
            var futureDate = DateTime.Now.AddDays(1);

            await Assert.ThrowsAsync<InvalidDateException>(() => _repository.GetConvertedAmountAsync(fromCurrency, originalAmount, toCurrency, futureDate));
        }
    }
}

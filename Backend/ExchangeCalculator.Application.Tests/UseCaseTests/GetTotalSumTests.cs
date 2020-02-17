using ExchangeCalculator.Application.UseCases;
using ExchangeCalculator.ServiceWrapper.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExchangeCalculator.Application.Tests.UseCaseTests
{
    public class GetTotalSumTests
    {
        private readonly GetTotalSum _useCase;

        public GetTotalSumTests()
        {
            _useCase = new GetTotalSum(new SweaMockRepository());
        }

        [Fact]
        public async void CanGetConvertedSum()
        {
            var conversionDates = new List<DateTime> { Convert.ToDateTime("2020-02-14"), Convert.ToDateTime("2020-02-17") };
            var fromCurrencies = new List<string> { "SEKGBPPMI", "SEKUSDPMI" };
            var originalAmounts = new List<decimal> { 150M, 275M };
            const string toCurrency = "SEKAUDPMI";

            var expectedSum = (1.94M * 150M) + (1.4869M * 275M);

            var sum = await _useCase.ExecuteAsync(conversionDates, fromCurrencies, originalAmounts, toCurrency);

            Assert.Equal(expectedSum, sum);
        }
    }
}
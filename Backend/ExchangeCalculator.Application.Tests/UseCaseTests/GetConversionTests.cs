using ExchangeCalculator.Application.UseCases;
using ExchangeCalculator.ServiceWrapper.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExchangeCalculator.Application.Tests.UseCaseTests
{
    public class GetConversionTests
    {
        private readonly GetConversion _useCase;

        public GetConversionTests()
        {
            _useCase = new GetConversion(new SweaMockRepository());
        }

        [Fact]
        public async void CanGetConversionAsync1()
        {          
            const decimal originalAmount = 150M;
            var expectedConvertedAmount = 1.2038M * originalAmount;
            const string fromCurrency = "SEKGBPPMI";
            const string toCurrency = "SEKEURPMI";
            var conversionDate = Convert.ToDateTime("2020-02-14");

            var conversion = await _useCase.ExecuteAsync(conversionDate, fromCurrency, originalAmount, toCurrency);

            Assert.Equal(expectedConvertedAmount, conversion.ConvertedAmount);
        }

        [Fact]
        public async void CanGetConversionAsync2()
        {         
            const decimal originalAmount = 275M;
            var expectedConvertedAmount = 9.2413M * originalAmount;
            const string fromCurrency = "SEKUSDPMI";
            const string toCurrency = "SEKNOKPMI";
            var conversionDate = Convert.ToDateTime("2020-02-17");

            var conversion = await _useCase.ExecuteAsync(conversionDate, fromCurrency, originalAmount, toCurrency);

            Assert.Equal(expectedConvertedAmount, conversion.ConvertedAmount);
        }
    }
}
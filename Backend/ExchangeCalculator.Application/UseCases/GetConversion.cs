using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Models.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace ExchangeCalculator.Application.UseCases
{
    public class GetConversion
    {
        private readonly ISweaRepository _repository;

        public GetConversion(ISweaRepository repository)
        {
            _repository = repository;
        }

        public async Task<DtoConversion> ExecuteAsync(DateTime conversionDate, string fromCurrency, decimal originalAmount, string toCurrency)
        {
            var conversionRate = await _repository.GetConversionRateAsync(fromCurrency, toCurrency, conversionDate);
            return new DtoConversion(conversionDate, fromCurrency, originalAmount, toCurrency, conversionRate * originalAmount);
        }
    }
}

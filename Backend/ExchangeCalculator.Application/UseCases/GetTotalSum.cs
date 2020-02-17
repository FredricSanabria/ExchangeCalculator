using ExchangeCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeCalculator.Application.UseCases
{
    public class GetTotalSum
    {
        private readonly ISweaRepository _repository;

        public GetTotalSum(ISweaRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> ExecuteAsync(List<DateTime> conversionDates, List<string> fromCurrencies, List<decimal> originalAmounts, string toCurrency)
        {
            decimal ret = 0M;
            var tasks = new List<Task<decimal>>();

            for (int i = 0; i < conversionDates.Count; i++)
            {
                tasks.Add(_repository.GetConvertedAmountAsync(fromCurrencies[i], originalAmounts[i], toCurrency, conversionDates[i]));
            }
            foreach (var task in await Task.WhenAll(tasks))
            {
                ret += task;
            }

            return ret;
        }
    }
}

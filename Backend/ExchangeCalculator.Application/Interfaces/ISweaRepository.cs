using ExchangeCalculator.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeCalculator.Application.Interfaces
{
    public interface ISweaRepository
    {
        Task<decimal> GetConvertedAmountAsync(string fromCurrency, decimal originalAmount, string toCurrency, DateTime conversionDate);
        List<Currency> GetCurrencies(bool includeObsolete = false);
    }
}

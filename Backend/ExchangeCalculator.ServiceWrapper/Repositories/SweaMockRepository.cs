using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Models.Domain;
using ExchangeCalculator.ServiceWrapper.Helpers;
using ExchangeCalculator.ServiceWrapper.Static;
using ExchangeCalculator.ServiceWrapper.XmlMock;
using ExchangeWrapper.SweaWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeCalculator.ServiceWrapper.Repositories
{
    public class SweaMockRepository : ISweaRepository
    {
        public List<Currency> GetCurrencies(bool includeObsolete = false)
        {
            var currencies = JsonConvert.DeserializeObject<List<Currency>>(CurrenciesJson.GetString());
            return includeObsolete
                ? currencies
                : currencies.Where(c => c.DateTo != null).ToList();
        }

        public async Task<decimal> GetConvertedAmountAsync(string fromCurrency, decimal originalAmount, string toCurrency, DateTime conversionDate)
        {
            var conversionRate = await GetConversionRateAsync(fromCurrency, toCurrency, conversionDate);
            return conversionRate * originalAmount;
        }

        public async Task<decimal> GetConversionRateAsync(string fromCurrency, string toCurrency, DateTime conversionDate)
        {
            if (conversionDate.Date > DateTime.Today)
                throw new InvalidDateException($"{conversionDate.ToSwedishDateString()} is a future date.");

            getCrossRatesResponse mockResponse;

            // XML responses collected from Swea WS
            if (fromCurrency == "SEKGBPPMI" && toCurrency == "SEKEURPMI" && conversionDate.ToSwedishDateString() == "2020-02-14")
            {
                mockResponse = GbpToEur200214.GetMockResponse();
            }
            else if (fromCurrency == "SEKGBPPMI" && toCurrency == "SEKAUDPMI" && conversionDate.ToSwedishDateString() == "2020-02-14")
            {
                mockResponse = GbpToAud200214.GetMockResponse();
            }
            else if (fromCurrency == "SEKGBPPMI" && toCurrency == "SEKEURPMI" && conversionDate.ToSwedishDateString() == "2020-02-15")
            {
                mockResponse = GbpToEur200215.GetMockResponse();
            }
            else if (fromCurrency == "SEKUSDPMI" && toCurrency == "SEKNOKPMI" && conversionDate.ToSwedishDateString() == "2020-02-17")
            {
                mockResponse = UsdToNok200217.GetMockResponse();
            }
            else if (fromCurrency == "SEKUSDPMI" && toCurrency == "SEKAUDPMI" && conversionDate.ToSwedishDateString() == "2020-02-17")
            {
                mockResponse = UsdToAud200217.GetMockResponse();
            }
            else
            {
                throw new ServiceWrapperException($"No GetConversionRate mock configured for {fromCurrency}, {toCurrency}, {conversionDate.ToSwedishDateString()}");
            }

            var task = Task.Run(() => CrossRateConversionResponseHelper.GetConversionRateFromServiceResponse(mockResponse, fromCurrency, toCurrency, conversionDate));

            return await task;
        }
    }
}

using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Models.Domain;
using ExchangeCalculator.ServiceWrapper.Helpers;
using ExchangeCalculator.ServiceWrapper.Static;
using ExchangeCalculator.ServiceWrapper.XmlMock;
using ExchangeWrapper.SweaWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeCalculator.ServiceWrapper.Repositories
{
    public class SweaMockRepository : ISweaRepository
    {
        public List<Currency> GetCurrencies(bool includeObsolete = false)
        {
            var currencies = JsonConvert.DeserializeObject<List<Currency>>(CurrenciesJson.GetString());
            return includeObsolete
                ? currencies
                : currencies.Where(c => c.DateTo == null).ToList();
        }

        public async Task<decimal> GetConvertedAmountAsync(string fromCurrency, decimal originalAmount, string toCurrency, DateTime conversionDate)
        {
            if (conversionDate.Date > DateTime.Today)
                throw new InvalidDateException($"{conversionDate.ToSwedishDateString()} is a future date.");

            if (fromCurrency == toCurrency)
                return originalAmount;

            var conversionRate = await GetConversionRateAsync(fromCurrency, toCurrency, conversionDate);
            return conversionRate * originalAmount;
        }

        private async Task<decimal> GetConversionRateAsync(string fromCurrency, string toCurrency, DateTime conversionDate)
        {
            getCrossRatesResponse mockResponse;

            if (fromCurrency == "SEKGBPPMI" && toCurrency == "SEKEURPMI" && conversionDate.ToSwedishDateString() == "2020-02-14")
            {
                mockResponse = GetMockResponse(GbpToEur200214.GetMockXml());
            }
            else if (fromCurrency == "SEKGBPPMI" && toCurrency == "SEKAUDPMI" && conversionDate.ToSwedishDateString() == "2020-02-14")
            {
                mockResponse = GetMockResponse(GbpToAud200214.GetMockXml());
            }
            else if (fromCurrency == "SEKUSDPMI" && toCurrency == "SEKNOKPMI" && conversionDate.ToSwedishDateString() == "2020-02-17")
            {
                mockResponse = GetMockResponse(UsdToNok200217.GetMockXml());
            }
            else if (fromCurrency == "SEKUSDPMI" && toCurrency == "SEKAUDPMI" && conversionDate.ToSwedishDateString() == "2020-02-17")
            {
                mockResponse = GetMockResponse(UsdToAud200217.GetMockXml());
            }
            else if (conversionDate.ToSwedishDateString() == "2020-02-15")
            {
                mockResponse = GetMockResponse(NotBankingDay.GetMockXml());
            }
            else
            {
                throw new ServiceWrapperException($"No GetConversionRate mock configured for {fromCurrency}, {toCurrency}, {conversionDate.ToSwedishDateString()}");
            }

            // cheating with running sync code as async only in mock/test situation
            var task = Task.Run(() => CrossRateConversionResponseHelper.GetConversionRateFromServiceResponse(mockResponse, fromCurrency, toCurrency, conversionDate));
            return await task;
        }

        private static getCrossRatesResponse GetMockResponse(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(getCrossRatesResponse));
            var bytes = Encoding.UTF8.GetBytes(xml);
            var stream = new MemoryStream(bytes);
            return (getCrossRatesResponse)xmlSerializer.Deserialize(stream);
        }
    }
}

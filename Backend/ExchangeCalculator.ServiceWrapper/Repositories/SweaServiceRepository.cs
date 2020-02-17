using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Models.Domain;
using ExchangeCalculator.ServiceWrapper.Helpers;
using ExchangeCalculator.ServiceWrapper.Static;
using ExchangeWrapper.SweaWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace ExchangeCalculator.ServiceWrapper.Repositories
{
    public class SweaServiceRepository : ISweaRepository
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

            if (fromCurrency == toCurrency)
            {
                const decimal conversionRate = 1M;
                return conversionRate;
            }

            var serviceResponse = await CallSweaForCrossRate(fromCurrency, toCurrency, conversionDate);

            return CrossRateConversionResponseHelper.GetConversionRateFromServiceResponse(serviceResponse, fromCurrency, toCurrency, conversionDate);
        }

        private async Task<getCrossRatesResponse> CallSweaForCrossRate(string fromCurrency, string toCurrency, DateTime conversionDate)
        {
            var sweaWsClient = new SweaWebServicePortTypeClient();
            var parameters = CrossRateConversionRequestHelper.GetParameters(fromCurrency, toCurrency, conversionDate);

            using (var scope = new FlowingOperationContextScope(sweaWsClient.InnerChannel))
            {
                var request = new HttpRequestMessageProperty();
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                
                // this is crucial, without action="urn:[methodName]" the call to Swea WS will result in 404 error.
                request.Headers.Add("Content-Type", @"application/soap+xml;charset=UTF-8;action=""urn:getCrossRates""");

                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = request;

                return await sweaWsClient.getCrossRatesAsync(parameters).ContinueOnScope(scope);
            }
        }
    }
}
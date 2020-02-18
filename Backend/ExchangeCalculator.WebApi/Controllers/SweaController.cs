using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Application.UseCases;
using ExchangeCalculator.ServiceWrapper.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeCalculator.WebApi.Controllers
{
    [Route("api/Swea")]
    [ApiController]
    public class SweaController : Controller
    {
        private readonly ISweaRepository _repository;

        public SweaController(ISweaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetCurrencies")]
        public JsonResult GetCurrencies()
        {
            try
            {
                var useCase = new GetCurrencies(_repository);
                return Json(useCase.Execute());
            }
            catch (Exception ex)
            {
                // TODO: Log.Error("api/Swea/GetCurrencies", ex);
                throw new ExchangeCalculatorException("Error getting currencies.");
            }
        }

        [HttpGet]
        [Route("GetConversion")]
        public async Task<JsonResult> GetConversion(DateTime conversionDate, string fromCurrency, decimal originalAmount, string toCurrency)
        {
            try
            {
                var useCase = new GetConversion(_repository);
                return Json(await useCase.ExecuteAsync(conversionDate, fromCurrency, originalAmount, toCurrency));
            }
            catch (Exception ex)
            {
                // TODO: Log.Error("api/Swea/GetConversion", ex);
                throw new ExchangeCalculatorException($"Error getting conversion from {originalAmount} {fromCurrency} to {toCurrency} for {conversionDate.ToSwedishDateString()}.");
            }
        }

        [HttpPost]
        [Route("GetTotalSum")]
        public async Task<JsonResult> GetTotalSum(string json)
        {
            try
            {
                ParseJson(JObject.Parse(json), out List<DateTime> conversionDates, out List<string> fromCurrencies, out List<decimal> originalAmounts, out string toCurrency);

                var useCase = new GetTotalSum(_repository);
                return Json(await useCase.ExecuteAsync(conversionDates, fromCurrencies, originalAmounts, toCurrency));
            }
            catch (Exception ex)
            {
                // TODO: Log.Error("api/Swea/GetConversion", ex);
                throw new ExchangeCalculatorException($"Error getting total sum from {json}.");
            }
        }

        private void ParseJson(JObject json, out List<DateTime> conversionDates, out List<string> fromCurrencies, out List<decimal> originalAmounts, out string toCurrency)
        {
            conversionDates = new List<DateTime>();
            fromCurrencies = new List<string>();
            originalAmounts = new List<decimal>();

            var conversions = json["conversions"].Children().ToList();
            toCurrency = json["toCurrency"].ToString();

            foreach (var conversion in conversions)
            {
                conversionDates.Add(Convert.ToDateTime(conversion["conversionDate"]));
                fromCurrencies.Add(conversion["fromCurrency"].ToString());
                originalAmounts.Add(Convert.ToDecimal(conversion["originalAmount"]));
            }
        }
        // example JSON:
        /*
        {
            "conversions": [
            {
                "conversionDate": "2020-02-14",
                "fromCurrency": "SEKGBPPMI",
                "originalAmount": 159
            },
            {
                "conversionDate": "2020-02-17",
                "fromCurrency": "SEKUSDPMI",
                "originalAmount": 275
            }
            ],
            "toCurrency": "SEKAUDPMI"
        }
        */
    }
}

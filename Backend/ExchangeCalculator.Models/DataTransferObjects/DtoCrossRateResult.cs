using System;

namespace ExchangeCalculator.Models.DataTransferObjects
{
    public sealed class DtoConversion
    {
        public DateTime ConversionDate { private set; get; }
        public string FromCurrency { private set; get; }
        public decimal OriginalAmount { private set; get; }
        public string ToCurrency { private set; get; }
        public decimal ConvertedAmount { private set; get; }

        public DtoConversion(DateTime conversionDate, string fromCurrency, decimal originalAmount, string toCurrency, decimal convertedAmount)
        {
            FromCurrency = fromCurrency;
            OriginalAmount = originalAmount;
            ToCurrency = toCurrency;
            ConversionDate = conversionDate;
            ConvertedAmount = convertedAmount;
        }
    }
}

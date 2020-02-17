using System;

namespace ExchangeCalculator.ServiceWrapper.Helpers
{
    public static class PublicExtensions
    {
        public static decimal ScientificNotationToDecimal(this double? d)
        {
            decimal.TryParse(d.ToString(), out decimal ret);

            // TODO: error handling?
            return ret;
        }

        public static string ToSwedishDateString(this DateTime dateTime)
        {
            if (dateTime == null) return string.Empty;
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}

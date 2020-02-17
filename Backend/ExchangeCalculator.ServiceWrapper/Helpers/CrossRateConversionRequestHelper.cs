using ExchangeWrapper.SweaWS;
using System;

namespace ExchangeCalculator.ServiceWrapper.Helpers
{
    internal class CrossRateConversionRequestHelper
    {
        // XML request sample at the end of this file
        public static CrossRequestParameters GetParameters(string fromCurrency, string toCurrency, DateTime conversionDate)
        {
            var crossPair = new CurrencyCrossPair[1];
            crossPair[0] = new CurrencyCrossPair
            {
                seriesid1 = fromCurrency,
                seriesid2 = toCurrency
            };

            return new CrossRequestParameters
            {
                aggregateMethod = AggregateMethodType.D,
                crossPair = crossPair,
                datefrom = conversionDate,
                dateto = conversionDate,
                languageid = LanguageType.en
            };
        }
    }
}

// XML request sample for getting conversion rate from GBP to EUR for 2020-02-14
/*
<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope" xmlns:xsd="http://swea.riksbank.se/xsd">
	<soap:Header/>
	<soap:Body>
		<xsd:getCrossRates>
			<crossRequestParameters>
				<aggregateMethod>D</aggregateMethod>
				<!--1 or more repetitions:-->
				<crossPair>
					<seriesid1>SEKGBPPMI</seriesid1>
					<seriesid2>SEKEURPMI</seriesid2>
				</crossPair>
				<datefrom>2020-02-14</datefrom>
				<dateto>2020-02-14</dateto>
				<languageid>en</languageid>
			</crossRequestParameters>
		</xsd:getCrossRates>
	</soap:Body>
</soap:Envelope>
*/

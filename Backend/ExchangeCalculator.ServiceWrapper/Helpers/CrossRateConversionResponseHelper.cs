using ExchangeCalculator.Models.Domain;
using ExchangeWrapper.SweaWS;
using System;

namespace ExchangeCalculator.ServiceWrapper.Helpers
{
    internal class CrossRateConversionResponseHelper
    {
        // XML response sample at the end of this file.
        public static decimal GetConversionRateFromServiceResponse(getCrossRatesResponse serviceResponse, string fromCurrency, string toCurrency, DateTime conversionDate)
        {
            if (serviceResponse.@return.groups == null) // no groups (data) returned, probably not a banking day.
                throw new InvalidDateException($"{conversionDate.ToSwedishDateString()} is probably not a banking day.");

            foreach (var serie in serviceResponse.@return.groups[0].series)
            {
                if (fromCurrency != serie.seriesid1)
                    continue; // this serie gives us conversion rate from currencyTo to currencyFrom which we're not interested in, move on.

                // we sent in a timespan of one day so it should only get one resultrow
                var resultrow = serie.resultrows[0];

                return resultrow.value.ScientificNotationToDecimal();
            }

            // TODO: Log
            throw new ServiceWrapperException($"Couldn't get conversion rate for {fromCurrency} to {toCurrency} for {conversionDate.ToSwedishDateString()}.");
        }
    }
}

// XML response sample for getting conversion rate from GBP to EUR for 2020-02-14
/*
<?xml version="1.0" encoding="UTF-8"?>
<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://www.w3.org/2003/05/soap-envelope">
    <SOAP-ENV:Body>
        <ns0:getCrossRatesResponse xmlns:ns0="http://swea.riksbank.se/xsd">
            <return xmlns="">
                <datefrom xmlns="">2020-02-14</datefrom>
                <dateto xmlns="">2020-02-14</dateto>
                <informationtext xmlns="">The Swedish banks daily calculate a fixing rate at 9.30 a.m. according to the formula: (bid+asked) / 2. At 10.05 a.m. Stockholm Stock Exchange sets a joint MID-PRICE by calculating the aggregate of the banks' fixing rates.&#xD;
&#xD;
Observations are published daily at 12.15 p.m.</informationtext>
                <groups xmlns="">
                    <groupid xmlns="">130</groupid>
                    <groupname xmlns="">Currencies against Swedish kronor</groupname>
                    <series xmlns="">
                        <seriesid1 xmlns="">SEKEURPMI</seriesid1>
                        <seriesid2 xmlns="">SEKGBPPMI</seriesid2>
                        <seriesname xmlns="">1 EUR = ? GBP</seriesname>
                        <resultrows xmlns="">
                            <date xmlns="">2020-02-14</date>
                            <period xmlns:ns1="http://www.w3.org/2001/XMLSchema-instance" xmlns="" ns1:nil="true"/>
                            <average xmlns:ns1="http://www.w3.org/2001/XMLSchema-instance" xmlns="" ns1:nil="true"/>
                            <value xmlns="">8.307E-1</value>
                        </resultrows>
                    </series>
                    <series xmlns="">
                        <seriesid1 xmlns="">SEKGBPPMI</seriesid1>
                        <seriesid2 xmlns="">SEKEURPMI</seriesid2>
                        <seriesname xmlns="">1 GBP = ? EUR</seriesname>
                        <resultrows xmlns="">
                            <date xmlns="">2020-02-14</date>
                            <period xmlns:ns1="http://www.w3.org/2001/XMLSchema-instance" xmlns="" ns1:nil="true"/>
                            <average xmlns:ns1="http://www.w3.org/2001/XMLSchema-instance" xmlns="" ns1:nil="true"/>
                            <value xmlns="">1.2038E0</value>
                        </resultrows>
                    </series>
                </groups>
            </return>
        </ns0:getCrossRatesResponse>
    </SOAP-ENV:Body>
</SOAP-ENV:Envelope>
*/
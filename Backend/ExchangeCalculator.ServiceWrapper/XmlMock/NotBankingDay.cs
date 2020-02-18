namespace ExchangeCalculator.ServiceWrapper.XmlMock
{
    internal class NotBankingDay
    {
        // XML response collected from Swea WS
        // Not banking day (Saturday) = empty response (no "groups" node).
        public static string GetMockXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <getCrossRatesResponse namespace=""http://swea.riksbank.se/xsd"">
        <return xmlns="""">
                <datefrom xmlns="""">2020-02-15</datefrom>
                <dateto xmlns="""">2020-02-15</dateto>
                <informationtext xmlns="""">The Swedish banks daily calculate a fixing rate at 9.30 a.m. according to the formula: (bid+asked) / 2. At 10.05 a.m. Stockholm Stock Exchange sets a joint MID-PRICE by calculating the aggregate of the banks' fixing rates.&#xD;
&#xD;
Observations are published daily at 12.15 p.m.</informationtext>
            </return>
    </getCrossRatesResponse>";
        }
    }
}

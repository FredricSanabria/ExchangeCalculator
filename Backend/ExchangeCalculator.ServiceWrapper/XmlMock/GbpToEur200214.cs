namespace ExchangeCalculator.ServiceWrapper.XmlMock
{
    internal class GbpToEur200214
    {
        // XML response collected from Swea WS
        public static string GetMockXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <getCrossRatesResponse namespace=""http://swea.riksbank.se/xsd"">
        <return xmlns="""">
            <datefrom xmlns="""">2020-02-14</datefrom>
            <dateto xmlns="""">2020-02-14</dateto>
            <informationtext xmlns="""">The Swedish banks daily calculate a fixing rate at 9.30 a.m. according to the formula: (bid+asked) / 2. At 10.05 a.m. Stockholm Stock Exchange sets a joint MID-PRICE by calculating the aggregate of the banks' fixing rates.&#xD;
    &#xD;
    Observations are published daily at 12.15 p.m.</informationtext>
            <groups xmlns="""">
                <groupid xmlns="""">130</groupid>
                <groupname xmlns="""">Currencies against Swedish kronor</groupname>
                <series xmlns="""">
                    <seriesid1 xmlns="""">SEKEURPMI</seriesid1>
                    <seriesid2 xmlns="""">SEKGBPPMI</seriesid2>
                    <seriesname xmlns="""">1 EUR = ? GBP</seriesname>
                    <resultrows xmlns="""">
                        <date xmlns="""">2020-02-14</date>
                        <period xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                        <average xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                        <value xmlns="""">8.307E-1</value>
                    </resultrows>
                </series>
                <series xmlns="""">
                    <seriesid1 xmlns="""">SEKGBPPMI</seriesid1>
                    <seriesid2 xmlns="""">SEKEURPMI</seriesid2>
                    <seriesname xmlns="""">1 GBP = ? EUR</seriesname>
                    <resultrows xmlns="""">
                        <date xmlns="""">2020-02-14</date>
                        <period xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                        <average xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                        <value xmlns="""">1.2038E0</value>
                    </resultrows>
                </series>
            </groups>
        </return>
    </getCrossRatesResponse>";
        }
    }
}

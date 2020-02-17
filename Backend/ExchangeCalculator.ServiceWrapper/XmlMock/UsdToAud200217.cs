using ExchangeWrapper.SweaWS;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ExchangeCalculator.ServiceWrapper.XmlMock
{
    internal class UsdToAud200217
    {
        public static getCrossRatesResponse GetMockResponse()
        {
            var xmlSerializer = new XmlSerializer(typeof(getCrossRatesResponse));
            var xml = GetXml();
            var bytes = Encoding.UTF8.GetBytes(xml);
            var stream = new MemoryStream(bytes);
            return (getCrossRatesResponse)xmlSerializer.Deserialize(stream);
        }

        // XML response collected from Swea WS
        private static string GetXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <getCrossRatesResponse namespace=""http://swea.riksbank.se/xsd"">
        <return xmlns="""">
                <datefrom xmlns="""">2020-02-17</datefrom>
                <dateto xmlns="""">2020-02-17</dateto>
                <informationtext xmlns="""">The Swedish banks daily calculate a fixing rate at 9.30 a.m. according to the formula: (bid+asked) / 2. At 10.05 a.m. Stockholm Stock Exchange sets a joint MID-PRICE by calculating the aggregate of the banks' fixing rates.&#xD;
&#xD;
Observations are published daily at 12.15 p.m.</informationtext>
                <groups xmlns="""">
                    <groupid xmlns="""">130</groupid>
                    <groupname xmlns="""">Currencies against Swedish kronor</groupname>
                    <series xmlns="""">
                        <seriesid1 xmlns="""">SEKAUDPMI</seriesid1>
                        <seriesid2 xmlns="""">SEKUSDPMI</seriesid2>
                        <seriesname xmlns="""">1 AUD = ? USD</seriesname>
                        <resultrows xmlns="""">
                            <date xmlns="""">2020-02-17</date>
                            <period xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                            <average xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                            <value xmlns="""">6.725E-1</value>
                        </resultrows>
                    </series>
                    <series xmlns="""">
                        <seriesid1 xmlns="""">SEKUSDPMI</seriesid1>
                        <seriesid2 xmlns="""">SEKAUDPMI</seriesid2>
                        <seriesname xmlns="""">1 USD = ? AUD</seriesname>
                        <resultrows xmlns="""">
                            <date xmlns="""">2020-02-17</date>
                            <period xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                            <average xmlns:ns1=""http://www.w3.org/2001/XMLSchema-instance"" xmlns="""" ns1:nil=""true""/>
                            <value xmlns="""">1.4869E0</value>
                        </resultrows>
                    </series>
                </groups>
            </return>
    </getCrossRatesResponse>";
        }
    }
}

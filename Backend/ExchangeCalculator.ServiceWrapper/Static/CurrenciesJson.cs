namespace ExchangeCalculator.ServiceWrapper.Static
{
    public class CurrenciesJson
    {
        public static string GetString()
        {

#warning 'Hardcoded data that might have to be updated manually. SweaWS doesn't have a service for currencies that include common name or any obsolete flag, therefore we have this list.'

            return @"
    [{ 
         ""id"":""SEKATSPMI"",
         ""name"":""ATS Österrike, shilling"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKAUDPMI"",
         ""name"":""AUD Australien, dollar"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKBEFPMI"",
         ""name"":""BEF Belgien, franc"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKBRLPMI"",
         ""name"":""BRL Brasilien, real"",
         ""dateFrom"":""2005-09-06"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKCADPMI"",
         ""name"":""CAD Canada, dollar"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKCHFPMI"",
         ""name"":""CHF Schweiz, franc"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKCNYPMI"",
         ""name"":""CNY Kina, yuan renminbi"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKCYPPMI"",
         ""name"":""CYP Cypern, pund"",
         ""dateFrom"":""1998-01-02"",
         ""dateTo"":""2007-12-28""
      },
      { 
         ""id"":""SEKCZKPMI"",
         ""name"":""CZK Tjeckien, kronor"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKDEMPMI"",
         ""name"":""DEM Tyskland, mark"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKDKKPMI"",
         ""name"":""DKK Danmark, kronor"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKEEKPMI"",
         ""name"":""EEK Estland, kronor"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""2010-12-30""
      },
      { 
         ""id"":""SEKESPPMI"",
         ""name"":""ESP Spanien, pesetas"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKEURPMI"",
         ""name"":""EUR Euroland, euro"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKFIMPMI"",
         ""name"":""FIM Finland, mark"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKFRFPMI"",
         ""name"":""FRF Frankrike, franc"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKGBPPMI"",
         ""name"":""GBP Storbritannien, pund"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKGRDPMI"",
         ""name"":""GRD Grekland, drachmer"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKHKDPMI"",
         ""name"":""HKD Hong Kong, dollar"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKHUFPMI"",
         ""name"":""HUF Ungern, forint"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKIDRPMI"",
         ""name"":""IDR Indonesien, rupee"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKIEPPMI"",
         ""name"":""IEP Irland, pund"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKINRPMI"",
         ""name"":""INR Indien, rupee"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKISKPMI"",
         ""name"":""ISK Island, kronor"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKITLPMI"",
         ""name"":""ITL Italien, lire"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKJPYPMI"",
         ""name"":""JPY Japan, yen"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKKRWPMI"",
         ""name"":""KRW Syd Korea, won"",
         ""dateFrom"":""2005-09-09"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKKWDPMI"",
         ""name"":""KWD Kuwait, dinar"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""2005-02-28""
      },
      { 
         ""id"":""SEKLTLPMI"",
         ""name"":""LTL Litauen, litas"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""2014-12-30""
      },
      { 
         ""id"":""SEKLVLPMI"",
         ""name"":""LVL Lettland, lav"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""2013-12-30""
      },
      { 
         ""id"":""SEKMADPMI"",
         ""name"":""MAD Marocko, dirham"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKMXNPMI"",
         ""name"":""MXN Mexiko, nuevo peso"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKMYRPMI"",
         ""name"":""MYR Malaysia, ringitt"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""2005-02-28""
      },
      { 
         ""id"":""SEKNLGPMI"",
         ""name"":""NLG Nederländerna, gulden"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKNOKPMI"",
         ""name"":""NOK Norge, kronor"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKNZDPMI"",
         ""name"":""NZD Nya Zeeland, dollar"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKPLNPMI"",
         ""name"":""PLN Polen, zloty"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKPTEPMI"",
         ""name"":""PTE Portugal, escudo"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""2002-02-28""
      },
      { 
         ""id"":""SEKRUBPMI"",
         ""name"":""RUB Ryssland, rubel"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKSARPMI"",
         ""name"":""SAR Saudiarabien, riyal"",
         ""dateFrom"":""1994-03-04"",
         ""dateTo"":""""
      },
	  { 
         ""id"":""SEK"",
         ""name"":""SEK Sverige, kronor"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKSGDPMI"",
         ""name"":""SGD Singapore, dollar"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKSITPMI"",
         ""name"":""SIT Slovenien, tolar"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""2006-12-29""
      },
      { 
         ""id"":""SEKSKKPMI"",
         ""name"":""SKK Slovakien, koruna"",
         ""dateFrom"":""2005-04-29"",
         ""dateTo"":""2009-01-01""
      },
      { 
         ""id"":""SEKTHBPMI"",
         ""name"":""THB Thailand, baht"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKTRLPMI"",
         ""name"":""TRL Turkiet, lira"",
         ""dateFrom"":""1998-01-01"",
         ""dateTo"":""2004-12-30""
      },
      { 
         ""id"":""SEKTRYPMI"",
         ""name"":""TRY Turkiet, ny lira"",
         ""dateFrom"":""2005-01-03"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKUSDPMI"",
         ""name"":""USD Förenta Staterna, dollar"",
         ""dateFrom"":""1993-01-04"",
         ""dateTo"":""""
      },
      { 
         ""id"":""SEKZARPMI"",
         ""name"":""ZAR Sydafrika, rand"",
         ""dateFrom"":""1994-03-01"",
         ""dateTo"":""""
      }]";
#pragma warning restore CS1030 // #warning directive
        }
    }
}

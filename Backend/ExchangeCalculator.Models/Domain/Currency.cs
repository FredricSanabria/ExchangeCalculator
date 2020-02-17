using System;

namespace ExchangeCalculator.Models.Domain
{
    public sealed class Currency
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public DateTime DateFrom { set; get; }
        public DateTime? DateTo { set; get; }

        public Currency(string id, string name, DateTime dateFrom, DateTime? dateTo)
        {
            Id = id;
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}

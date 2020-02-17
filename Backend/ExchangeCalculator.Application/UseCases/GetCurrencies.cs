using ExchangeCalculator.Application.Interfaces;
using ExchangeCalculator.Models.Domain;
using System.Collections.Generic;

namespace ExchangeCalculator.Application.UseCases
{
    public class GetCurrencies
    {
        private readonly ISweaRepository _repository;

        public GetCurrencies(ISweaRepository repository)
        {
            _repository = repository;
        }

        public List<Currency> Execute(bool includeObsolete = false)
        {
            return _repository.GetCurrencies(includeObsolete);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdcn.Application.Contract.Dto;
using Cdcn.Application.Core.Abstraction.Messaging;
using Cdcn.Domain.Core.Primitives.Maybe;
using Cdcn.Domain.Repositories;

namespace Cdcn.Application.UseCases.Currencies.Query.GetCurrencyByCode
{
    public sealed class GetCurrencyByCodeQueryHandler : IQueryHandler<GetCurrencyByCodeQuery, Maybe<Currency>>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public GetCurrencyByCodeQueryHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<Maybe<Currency>> Handle(GetCurrencyByCodeQuery request, CancellationToken cancellationToken)
        {
            var courtCase = await _currencyRepository.GetByCode(request.code);

            if (courtCase == null )
            {
                return Maybe<Currency>.None;
            }

            var currency = new Currency
            {
               Code = courtCase.Code,
               Name = courtCase.Name,
               Symbol = courtCase.Symbol,
            };

            return currency;
        }
    }
}

using Cdcn.Application.Contract.Dto;
using Cdcn.Application.Core.Abstraction.Messaging;
using Cdcn.Domain.Core.Primitives.Maybe;

namespace Cdcn.Application.UseCases.Currencies.Query.GetCurrencyByCode
{


    public record GetCurrencyByCodeQuery(string code) : IQuery<Maybe<Currency>>;
}

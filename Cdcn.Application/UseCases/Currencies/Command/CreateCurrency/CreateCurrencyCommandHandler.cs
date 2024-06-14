using Cdcn.Application.Contract;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Domain.Entities;
using Cdcn.Domain.Repositories;
using MediatR;

namespace Cdcn.Application.UseCases.Currencies.Command.CreateCurrency
{


    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Result<IdResponse>>
    {
        protected readonly ICurrencyRepository _currencyRepository;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<Result<IdResponse>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = new Currency(request.code, request.name, request.symbol);

            await _currencyRepository.Insert(currency);

            return Result.Success(new IdResponse(currency.Id));

        }
    }
}

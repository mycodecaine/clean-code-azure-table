using Cdcn.Application.Contract;
using Cdcn.Domain.Core.Errors;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Domain.Entities;
using Cdcn.Domain.Repositories;
using MediatR;

namespace Cdcn.Application.UseCases.Currencies.Command.CreateCurrency
{


    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Result<IdResponse>>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<Result<IdResponse>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = new Currency(request.code.ToUpper(), request.name, request.symbol);

            if (!await _currencyRepository.IsCodeUniqueAsync(request.code.ToUpper())){
                return Result.Failure<IdResponse>(DomainErrors.Currency.DuplicateCode);
            }

            await _currencyRepository.InsertAsync(currency);

            await _currencyRepository.CommitAsync();

            return Result.Success(new IdResponse(currency.Id));

        }
    }
}

using Cdcn.Application.Contract;
using Cdcn.Application.UseCases.Currencies.Command.CreateCurrency;
using Cdcn.Domain.Core.Errors;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.UseCases.Currencies.Command.UpdateCurrency
{
   

    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, Result<IdResponse>>
    {
        protected readonly ICurrencyRepository _currencyRepository;

        public UpdateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<Result<IdResponse>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _currencyRepository.GetByCode(request.request.Code.ToUpper());

            if (currency == null)
            {
                return Result.Failure<IdResponse>(DomainErrors.Currency.CurrencyNotExist);
            }

            currency.Code = request.request.Code;
            currency.Name = request.request.Name;
            currency.Symbol = request.request.Symbol;
            await _currencyRepository.UpdateAsync(currency);

            return Result.Success(new IdResponse(currency.Id));

        }
    }
}

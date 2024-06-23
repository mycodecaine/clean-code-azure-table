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

namespace Cdcn.Application.UseCases.Currencies.Command.DeleteCurrency
{
    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, Result>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public DeleteCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<Result> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _currencyRepository.GetByCode(request.code.ToUpper());

            if (currency == null)
            {
                return Result.Failure(DomainErrors.Currency.CurrencyNotExist);
            }

            await _currencyRepository.Delete(currency.Id);

            return Result.Success();
        }
    }
}

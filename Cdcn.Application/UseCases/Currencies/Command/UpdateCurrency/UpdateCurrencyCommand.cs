using Cdcn.Application.Contract;
using Cdcn.Application.UseCases.Currencies.Command.UpdateCurrency.Contracts;
using Cdcn.Domain.Core.Primitives.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.UseCases.Currencies.Command.UpdateCurrency
{
    

    public record UpdateCurrencyCommand(UpdateCurrencyRequest request) : IRequest<Result<IdResponse>>;
}

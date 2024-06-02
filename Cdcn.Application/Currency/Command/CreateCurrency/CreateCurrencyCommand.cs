using Cdcn.Application.Contract;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Domain.Enumerations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.Currencies.Command.CreateCurrency
{
    
    public record CreateCurrencyCommand(string code, string name, string symbol) : IRequest<Result<IdResponse>>;

}

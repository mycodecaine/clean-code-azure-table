using Cdcn.Application.Contract;
using Cdcn.Domain.Core.Primitives.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.UseCases.Countries.Commands.CreateCountry
{
    public sealed class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<IdResponse>>
    {
        public Task<Result<IdResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

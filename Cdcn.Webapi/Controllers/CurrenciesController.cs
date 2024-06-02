using Cdcn.Application.Contract.Countries;
using Cdcn.Application.Contract;
using Cdcn.Application.Countries.Commands.CreateCountry;
using Cdcn.Domain.Core.Errors;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Webapi.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cdcn.Application.Contract.Currencies;
using Cdcn.Application.Currencies.Command.CreateCurrency;

namespace Cdcn.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : BaseController
    {
        public CurrenciesController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost(ApiRoutes.Currencies.Create)]
        [ProducesResponseType(typeof(IdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyRequest createCurrencyRequest) =>
          await Result.Create(createCurrencyRequest, DomainError.General.UnProcessableRequest)
              .Map(request => new CreateCurrencyCommand(createCurrencyRequest.Code, createCurrencyRequest.Name,createCurrencyRequest.Symbol ))
              .Bind(command => Mediator.Send(command))
              .Match(Ok, BadRequest);
    }
}

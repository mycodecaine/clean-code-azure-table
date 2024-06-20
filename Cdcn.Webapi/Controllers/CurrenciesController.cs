using Cdcn.Application.Contract;
using Cdcn.Domain.Core.Errors;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Webapi.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cdcn.Application.Contract.Currencies;
using Cdcn.Application.UseCases.Currencies.Command.CreateCurrency;
using Cdcn.Application.UseCases.Currencies.Command.DeleteCurrency;
using Cdcn.Application.UseCases.Currencies.Command.DeleteCurrency.Contracts;
using Cdcn.Application.UseCases.Currencies.Command.UpdateCurrency.Contracts;
using Cdcn.Application.UseCases.Currencies.Command.UpdateCurrency;

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
          await Result.Create(createCurrencyRequest, DomainErrors.General.UnProcessableRequest)
              .Map(request => new CreateCurrencyCommand(createCurrencyRequest.Code, createCurrencyRequest.Name,createCurrencyRequest.Symbol ))
              .Bind(command => Mediator.Send(command))
              .Match(Ok, BadRequest);

        [HttpPut(ApiRoutes.Currencies.Update)]
        [ProducesResponseType(typeof(IdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateCurrencyRequest request) =>
         await Result.Create(request, DomainErrors.General.UnProcessableRequest)
             .Map(request => new UpdateCurrencyCommand(request))
             .Bind(command => Mediator.Send(command))
             .Match(Ok, BadRequest);

        [HttpDelete(ApiRoutes.Currencies.Delete)]
        [ProducesResponseType( StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete( [FromBody] DeleteCurrencyRequest request) =>
          await Result.Create(request, DomainErrors.General.UnProcessableRequest)
              .Map(request => new DeleteCurrencyCommand(request.Code))
              .Bind(command => Mediator.Send(command))
              .Match(Ok, BadRequest);
    }
}

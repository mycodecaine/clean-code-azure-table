using Cdcn.Application.Contract;
using Cdcn.Application.Contract.Countries;
using Cdcn.Application.Countries.Commands.CreateCountry;
using Cdcn.Domain.Core.Errors;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Webapi.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cdcn.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    {
        protected CountryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.Countries.Create)]
        [ProducesResponseType(typeof(IdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCountryRequest createCountryRequest) =>
          await Result.Create(createCountryRequest, DomainError.General.UnProcessableRequest)
              .Map(request => new CreateCountryCommand(createCountryRequest.Name,createCountryRequest.Code, createCountryRequest.Capital, createCountryRequest.Population,
                  createCountryRequest.Area, createCountryRequest.Continent,createCountryRequest.CurrencyId, createCountryRequest.OfficialLanguage,
                  createCountryRequest.GDP, createCountryRequest.CallingCode, createCountryRequest.InternetTLD, createCountryRequest.FlagURL, createCountryRequest.WorldTimeZones

                  ))
              .Bind(command => Mediator.Send(command))
              .Match(Ok, BadRequest);
    }
}

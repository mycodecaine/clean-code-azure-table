using Cdcn.Application.Contract;
using Cdcn.Domain.Core.Primitives.Result;
using Cdcn.Domain.Enumerations;
using MediatR;

namespace Cdcn.Application.UseCases.Countries.Commands.CreateCountry
{
    public record CreateCountryCommand(string name, string code, string capital, int population, double area, Continent continent, Guid currencyId,
            string officialLanguage, decimal gdp, string callingCode, string internetTld, string flagurl, List<WorldTimeZone> worldTimeZones) : IRequest<Result<IdResponse>>;
}

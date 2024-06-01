using Cdcn.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.Contract.Countries
{
    public class CreateCountryRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public Continent Continent { get; set; }
        public Guid CurrencyId { get; set; }
        public string OfficialLanguage { get; set; }
        // Use IReadOnlyList for collections to ensure immutability
        public List<WorldTimeZone> WorldTimeZones { get; set; }

        public decimal GDP { get; set; }
        public string CallingCode { get; set; }
        public string InternetTLD { get; set; }
        public string FlagURL { get; set; }
    }
}

using Azure.Data.Tables;
using Cdcn.Domain.Core.Primitives;
using Cdcn.Domain.Enumerations;
using Cdcn.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Entities
{
    public class Country : Entity
    {
        // Default constructor needed for deserialization or ORM purposes
        public Country() : base(nameof(Country)) { }

        // Parameterized constructor to initialize mandatory properties
        public Country(string name, string code, string capital, int population, double area, Continent continent, Guid currencyId,
            string officialLanguage,decimal gdp,string callingCode,string internetTld,string flagurl)
            : base(nameof(Country))
        {
            Name = name;
            Code = code ;
            Capital = capital;
            Population = population;
            Area = area;
            Continent = continent ;
            CurrencyId = currencyId;
            OfficialLanguage = officialLanguage ;
            GDP = gdp ;
            CallingCode = callingCode ;
            InternetTLD = internetTld ;
            FlagURL = flagurl ;
        }


        // Properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public Continent Continent { get; set; }
        public Guid CurrencyId { get; set; }

        public string OfficialLanguage { get; set; }

        // Use IReadOnlyList for collections to ensure immutability
        public IReadOnlyList<WorldTimeZone> WorldTimeZones { get; private set; } = new List<WorldTimeZone>();

        public decimal GDP { get; set; }
        public string CallingCode { get; set; }
        public string InternetTLD { get; set; }
        public string FlagURL { get; set; }

        // Method to add a WorldTimeZone, ensuring the collection is immutable externally
        public void AddWorldTimeZone(WorldTimeZone worldTimeZone)
        {
            if (worldTimeZone == null) throw new ArgumentNullException(nameof(worldTimeZone));

            var timeZones = new List<WorldTimeZone>(WorldTimeZones) { worldTimeZone };
            WorldTimeZones = timeZones.AsReadOnly();
        }

        public  Task<Currency> GetCurrency(Guid currencyId, ICurrencyRepository currencyRepository)
        {
            return currencyRepository.GetByIdAsync(currencyId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cdcn.Domain.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Continent
    {
        Africa,
        Antarctica,
        Asia,
        Europe,
        NorthAmerica,
        Oceania,
        SouthAmerica
    }

    
}

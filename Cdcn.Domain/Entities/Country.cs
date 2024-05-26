using Azure.Data.Tables;
using Cdcn.Domain.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Entities
{
    public class Country : Entity
    {
        public Country() : base(nameof(Country))
        {
        }
    }
}

using Cdcn.Domain.Core.Primitives;
using Cdcn.Domain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Entities
{
    public class Currency : Entity
    {
        public Currency(string code,string name,string symbol) : base(nameof(Currency))
        {
            Ensure.NotEmpty(code, "The code  is required.", nameof(code));
            Ensure.NotEmpty(name, "The name  is required.", nameof(name));
            Ensure.NotEmpty(symbol, "The name  is required.", nameof(symbol));
            Code = code;
            Name = name;
            Symbol = symbol;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }


    }
}

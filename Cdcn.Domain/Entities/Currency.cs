using Cdcn.Domain.Core.Primitives;
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
            Code = code;
            Name = name;
            Symbol = symbol;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }


    }
}

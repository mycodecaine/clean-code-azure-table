using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.UseCases.Currencies.Command.DeleteCurrency.Contracts
{
    public class DeleteCurrencyRequest
    {
        public string Code { get; set; }
    }
}

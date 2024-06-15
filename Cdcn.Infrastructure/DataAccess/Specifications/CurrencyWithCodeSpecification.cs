using Cdcn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Infrastructure.DataAccess.Specifications
{
  

    internal sealed class CurrencyWithCodeSpecification : Specification<Currency>
    {
        private readonly string _code;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserWithEmailSpecification"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        internal CurrencyWithCodeSpecification(string code) => _code = code;

        /// <inheritdoc />
        internal override Expression<Func<Currency, bool>> ToExpression() => user => user.Code == _code;
    }
}

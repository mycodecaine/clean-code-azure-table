using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.Contract
{
    public class IdResponse
    {
        public IdResponse(Guid id) => Id = id;

        /// <summary>
        /// Gets the token.
        /// </summary>
        public Guid Id { get; }
    }
}

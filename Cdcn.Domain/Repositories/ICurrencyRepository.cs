﻿using Cdcn.Domain.Core.Persistence;
using Cdcn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Repositories
{
    

    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<bool> IsCodeUniqueAsync(string code);
        Task<Currency?> GetByCode(string code);
    }
}

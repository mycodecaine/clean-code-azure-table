using Azure.Data.Tables;
using Cdcn.Domain.Core.Persistence;
using Cdcn.Domain.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
       
    }

}

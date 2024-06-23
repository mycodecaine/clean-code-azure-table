using Azure.Data.Tables;
using Cdcn.Domain.Core.Data;
using Cdcn.Domain.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Core.Persistence
{
    public interface IGenericRepository<TEntity>: IUnitOfWork where TEntity : class, ITableEntity, new()
    {
        Task<TEntity> GetAsync(string partitionKey, string rowKey);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<TEntity>> QueryAsync(QueryFilter<TEntity> filter);
        Task<bool> IsUniqeAsync(QueryFilter<TEntity> filter);
    }   

}

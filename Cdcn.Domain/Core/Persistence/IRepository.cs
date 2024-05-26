using Cdcn.Domain.Core.Data;
using Cdcn.Domain.Core.Primitives;

namespace Cdcn.Domain.Core.Persistence
{


    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> QueryAsync(QueryFilter<TEntity> filter);

    }
}

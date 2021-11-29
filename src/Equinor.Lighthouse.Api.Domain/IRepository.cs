using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Domain
{
    public interface IRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        void Add(TEntity item);
        Task<bool> Exists(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetByIdsAsync(IEnumerable<Guid> id);
        void Remove(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
    }
}

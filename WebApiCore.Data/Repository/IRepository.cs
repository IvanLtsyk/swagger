using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Data.Domain;

namespace WebApiCore.Data.Repository
{
    public interface IRepository<TEntity,  TKey> where TEntity : class, IIdentifiableEntity<TKey>, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task DeleteAsync();
        Task<TEntity> FindByIdAsync(TKey key);
    }
}

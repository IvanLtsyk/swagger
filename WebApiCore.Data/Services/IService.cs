using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Data.Domain;

namespace WebApiCore.Data.Services
{
    public interface IService<TEntity, TKey> where TEntity : class, IIdentifiableEntity<TKey>, new()
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(TKey key);
    }
}

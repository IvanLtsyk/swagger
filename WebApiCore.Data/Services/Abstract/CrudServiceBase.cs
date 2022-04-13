using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Data.Domain;
using WebApiCore.Data.Repositories;

namespace WebApiCore.Data.Services.Abstract
{
    public abstract class CrudServiceBase<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class, IIdentifiableEntity<TKey>, new()
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        public CrudServiceBase(IRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }
        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public virtual Task<TEntity> FindByIdAsync(TKey key)
        {
            return _repository.FindByIdAsync(key);
        }

        public virtual Task<IList<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}

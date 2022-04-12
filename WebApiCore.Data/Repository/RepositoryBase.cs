
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Data.Domain;
using Microsoft.EntityFrameworkCore;


namespace WebApiCore.Data.Repository.impl
{
    public abstract class RepositoryBase<TEntity, TKey> 
        : IRepository<TEntity, TKey> where TEntity : class, IIdentifiableEntity<TKey>, new()
    {
        protected readonly DbContext _context;
        protected RepositoryBase(DbContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> Data => _context.Set<TEntity>()
                    .AsNoTracking();

        public Task AddAsync(TEntity entity)
        {
            return _context.AddAsync(entity);
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

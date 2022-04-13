
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Data.Domain;
using Microsoft.EntityFrameworkCore;


namespace WebApiCore.Data.Repositories.Abstract
{
    public abstract class EfRepositoryBase<TEntity, TKey> 
        : IRepository<TEntity, TKey> where TEntity : class, IIdentifiableEntity<TKey>, new()
    {
        private readonly DbContext _context;
        protected EfRepositoryBase(DbContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> Data => _context.Set<TEntity>()
                    .AsNoTracking();

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await  _context.SaveChangesAsync();

            return entity;
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
           return  _context.SaveChangesAsync();
        }

        public virtual Task<TEntity> FindByIdAsync(TKey key)
        {
            return Data.FirstOrDefaultAsync(m => Equals(m.Id, key));
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await Data.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

using Books.Web.Entities.Abstraction;
using Books.Web.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Web.Repositories
{
    public class GenericRepository<T, TContext> : IGenericRepository<T, TContext>
        where T : BaseEntity
        where TContext : DbContext
    {
        protected TContext _tContext;
        internal DbSet<T> _dbSet;
        public GenericRepository(TContext tContext)
        {
            _tContext = tContext;
            _dbSet = tContext.Set<T>();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            var entry = _dbSet.Add(entity); 
            await _tContext.SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<bool> DeleteAllAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAllAsync(expression);

            if (!entity.Any()) return false;

            await entity.ForEachAsync(e => e.IsDeleted = true);

            return await _tContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(long Id)
        {
            var entity = await _dbSet.FindAsync(Id);

            if (entity is null) return false;
            entity.IsDeleted = true;    
            return await _tContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
         =>  await Task.FromResult(predicate == null ? _dbSet : _dbSet.Where(predicate));

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
         => await _dbSet.FirstOrDefaultAsync(expression);

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _tContext.Update(entity);
            await _tContext.SaveChangesAsync();

            return entity;
        }
    }
}

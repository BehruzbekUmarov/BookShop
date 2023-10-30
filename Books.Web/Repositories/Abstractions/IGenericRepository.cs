using Book.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Web.Repositories.Abstractions
{
    public interface IGenericRepository<T, TContext>
        where T:class 
        where TContext : DbContext 
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long Id);
        Task<bool> DeleteAllAsync(Expression<Func<T, bool>> expression);
    }
}

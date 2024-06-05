using System.Linq.Expressions;
using Sukuposti.Domain.Models.Pagination;

namespace Sukuposti.Infrastructure.Repository.BaseRepository;

public interface IBaseRepository<T> where T : class
{
    Task<IQueryable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(uint id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(Expression<Func<T, bool>> expression, T entity);
    Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
}
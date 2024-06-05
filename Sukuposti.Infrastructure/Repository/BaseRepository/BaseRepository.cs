using Microsoft.EntityFrameworkCore;
using Sukuposti.Infrastructure.Context;
using System.Linq.Expressions;

namespace Sukuposti.Infrastructure.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApiContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApiContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _context.Database.SetCommandTimeout(200);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet
                .AsQueryable()
                .AsNoTracking());
        }
        
        public async Task<T?> GetByIdAsync(uint id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<T> UpdateAsync(Expression<Func<T, bool>> expression, T entity)
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(expression);
            
            _context.Entry(existingEntity)
                .CurrentValues
                .SetValues(entity);

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
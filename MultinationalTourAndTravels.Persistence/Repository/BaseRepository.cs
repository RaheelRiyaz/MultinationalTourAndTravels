using Microsoft.EntityFrameworkCore;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly MultinationalTourAndTravelsDbContext dbContext;
        protected DbSet<T> _dbSet;
        public BaseRepository(MultinationalTourAndTravelsDbContext dbContext)
        {
            this.dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }



        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await this.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return await this.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await this.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _dbSet.Remove(new T { Id = id });
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            List<T> entities = new List<T>();
            foreach (var id in ids)
            {
                entities.Add(new T { Id = id });
            }

            _dbSet.RemoveRange(entities);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => _dbSet.Where(expression));
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _dbSet);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return await SaveChangesAsync();
        }




        private async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}

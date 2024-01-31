using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface IBaseRepository<T>
    {
        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteRangeAsync(IEnumerable<Guid> ids);
        Task<int> DeleteRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T,bool>> expression);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T,bool>> expression);
        Task<bool> IsExistAsync(Expression<Func<T,bool>> expression);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersListAPI.Repositories.BaseRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}

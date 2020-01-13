﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersListAPI.Repositories.BaseRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}

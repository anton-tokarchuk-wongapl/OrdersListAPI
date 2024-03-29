﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrdersListAPI.Repositories.BaseRepository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly DbSet<T> entity;

        protected readonly DbContext context;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
            => await entity.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await entity.ToListAsync();

        public async Task AddAsync(T entity)
        {
            this.entity.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.entity.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.entity.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

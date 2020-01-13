using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Repositories.OrdersRepository
{
    public class OrdersRepository : BaseRepository<OrderEntity>, IOrdersRepository
    {
        public OrdersRepository(OrdersContext ordersContext) : base(ordersContext)
        {
        }

        public async override Task<OrderEntity> GetByIdAsync(int id)
            => await entity.Include(order => order.Product)
                           .Include(order => order.Status)
                           .FirstOrDefaultAsync();

        public async override Task<IEnumerable<OrderEntity>> GetAllAsync()
            => await entity.Include(order => order.Product)
                           .Include(order => order.Status)
                           .ToListAsync();

        public async override Task<IEnumerable<OrderEntity>> GetWhereAsync(Expression<Func<OrderEntity, bool>> expression)
            => await entity.Include(order => order.Product)
                           .Include(order => order.Status)
                           .Where(expression)
                           .ToListAsync();
    }
}

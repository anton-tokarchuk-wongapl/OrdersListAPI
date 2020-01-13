using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Repositories.OrdersRepository
{
    public class OrdersRepository : BaseRepository<OrderEntity>, IOrdersRepository
    {
        public OrdersRepository(OrdersContext ordersContext) : base(ordersContext)
        {
        }
    }
}

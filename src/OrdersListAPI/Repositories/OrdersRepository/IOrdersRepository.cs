using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Repositories.OrdersRepository
{
    public interface IOrdersRepository : IBaseRepository<OrderEntity>
    {
    }
}

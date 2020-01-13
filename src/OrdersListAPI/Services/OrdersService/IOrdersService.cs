using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;
using OrdersListAPI.Services.BaseService;

namespace OrdersListAPI.Services.OrdersService
{
    public interface IOrdersService : IBaseService<OrderDTO, OrderEntity>
    {
    }
}

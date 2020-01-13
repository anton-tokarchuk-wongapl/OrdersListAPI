using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.OrdersRepository;
using OrdersListAPI.Services.BaseService;

namespace OrdersListAPI.Services.OrdersService
{
    public class OrdersService : BaseService<OrderDTO, OrderEntity>, IOrdersService
    {
        public OrdersService(IMapper mapper, IOrdersRepository ordersRepository) : base(mapper, ordersRepository)
        {
        }
    }
}

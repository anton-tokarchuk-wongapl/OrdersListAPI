using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;

namespace OrdersListAPI.Infrastructure.MapperProfiles
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<OrderEntity, OrderDTO>(MemberList.None).ReverseMap();
        }
    }
}

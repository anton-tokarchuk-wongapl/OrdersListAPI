using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;

namespace OrdersListAPI.Infrastructure.MapperProfiles
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<ProductEntity, ProductDTO>(MemberList.None).ReverseMap();
        }
    }
}

using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;

namespace OrdersListAPI.Infrastructure.AutoMapperProfiles
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<ProductEntity, ProductDTO>(MemberList.None).ReverseMap();
        }
    }
}

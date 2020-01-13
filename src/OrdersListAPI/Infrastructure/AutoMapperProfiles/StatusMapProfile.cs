using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;

namespace OrdersListAPI.Infrastructure.AutoMapperProfiles
{
    public class StatusMapProfile : Profile
    {
        public StatusMapProfile()
        {
            CreateMap<StatusEntity, StatusDTO>(MemberList.None).ReverseMap();
        }
    }
}

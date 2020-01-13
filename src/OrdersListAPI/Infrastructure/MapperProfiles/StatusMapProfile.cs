using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;

namespace OrdersListAPI.Infrastructure.MapperProfiles
{
    public class StatusMapProfile : Profile
    {
        public StatusMapProfile()
        {
            CreateMap<StatusEntity, StatusDTO>(MemberList.None).ReverseMap();
        }
    }
}

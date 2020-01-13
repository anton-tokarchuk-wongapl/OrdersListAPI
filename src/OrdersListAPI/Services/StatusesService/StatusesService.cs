using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.StatusesRepository;
using OrdersListAPI.Services.BaseService;

namespace OrdersListAPI.Services.StatusesService
{
    public class StatusesService : BaseService<StatusDTO, StatusEntity>, IStatusesService
    {
        public StatusesService(IMapper mapper, IStatusesRepository repository) : base(mapper, repository)
        {
        }
    }
}

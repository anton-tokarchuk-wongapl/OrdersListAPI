using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;
using OrdersListAPI.Services.BaseService;

namespace OrdersListAPI.Services.StatusesService
{
    public interface IStatusesService : IBaseService<StatusDTO, StatusEntity>
    {
    }
}

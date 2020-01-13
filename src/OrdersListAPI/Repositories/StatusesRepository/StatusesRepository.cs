using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Repositories.StatusesRepository
{
    public class StatusesRepository : BaseRepository<StatusEntity>, IStatusesRepository
    {
        public StatusesRepository(OrdersContext ordersContext) : base(ordersContext)
        {

        }
    }
}

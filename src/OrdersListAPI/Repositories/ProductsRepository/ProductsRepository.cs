using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Repositories.ProductsRepository
{
    public class ProductsRepository : BaseRepository<ProductEntity>, IProductsRepository
    {
        public ProductsRepository(OrdersContext ordersContext) : base(ordersContext)
        {
        }
    }
}

using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Repositories.ProductsRepository
{
    public interface IProductsRepository : IBaseRepository<ProductEntity>
    {
    }
}

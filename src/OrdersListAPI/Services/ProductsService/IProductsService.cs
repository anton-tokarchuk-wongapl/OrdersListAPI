using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;
using OrdersListAPI.Services.BaseService;

namespace OrdersListAPI.Services.ProductsService
{
    public interface IProductsService : IBaseService<ProductDTO, ProductEntity>
    {
    }
}

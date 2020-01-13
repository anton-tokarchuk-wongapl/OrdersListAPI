using AutoMapper;
using OrdersListAPI.DTOs;
using OrdersListAPI.Entities;
using OrdersListAPI.Repositories.ProductsRepository;
using OrdersListAPI.Services.BaseService;

namespace OrdersListAPI.Services.ProductsService
{
    public class ProductsService : BaseService<ProductDTO, ProductEntity>, IProductsService
    {
        public ProductsService(IMapper mapper, IProductsRepository productsRepository) : base(mapper, productsRepository)
        {
        }
    }
}

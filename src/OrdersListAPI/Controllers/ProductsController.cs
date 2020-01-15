using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersListAPI.DTOs;
using OrdersListAPI.Infrastructure.Validation;
using OrdersListAPI.Services.ProductsService;

namespace OrdersListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [ValidateModel]
        [ResponseCache(Duration = 60)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var products = await productsService.GetAllAsync();

            return products.ToList();
        }

        [ValidateModel]
        [ResponseCache(Duration = 60)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await productsService.GetByIdAsync(id);

            if (Equals(product, null))
            {
                return NotFound();
            }

            return product;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateAsync([FromBody] ProductDTO productDTO)
        {
            await productsService.AddAsync(productDTO);
            return productDTO;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateAsync(int id, [FromBody] ProductDTO productDTO)
        {
            productDTO.Id = id;
            await productsService.UpdateAsync(productDTO);

            return productDTO;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateAsync([FromBody] ProductDTO productDTO)
        {
            await productsService.UpdateAsync(productDTO);
            return productDTO;
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> DeleteAsync(int id)
        {
            var product = await productsService.GetByIdAsync(id);

            if (Equals(product, null))
            {
                return NotFound();
            }

            await productsService.DeleteAsync(product);
            return product;
        }
    }
}

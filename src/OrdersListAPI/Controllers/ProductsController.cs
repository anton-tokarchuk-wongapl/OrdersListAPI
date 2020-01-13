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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await productsService.GetAllAsync();

            return products.ToList();
        }

        [ValidateModel]
        [ResponseCache(Duration = 60)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var isExists = await productsService.AnyAsync(product => product.Id == id);

            if (!isExists)
            {
                return NotFound();
            }

            return await productsService.GetByIdAsync(id);
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            await productsService.AddAsync(productDTO);

            return Ok(productDTO);
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (!Equals(id, productDTO.Id))
            {
                return BadRequest();
            }

            await productsService.UpdateAsync(productDTO);

            return Ok(productDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await productsService.GetByIdAsync(id);
            await productsService.DeleteAsync(dto);

            return Ok(dto);
        }

    }
}

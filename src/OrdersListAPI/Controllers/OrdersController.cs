using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersListAPI.DTOs;
using OrdersListAPI.Infrastructure.Validation;
using OrdersListAPI.Services.OrdersService;

namespace OrdersListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllAsync()
        {
            var products = await ordersService.GetAllAsync();

            return products.ToList();
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetByIdAsync(int id)
        {
            var dto = await ordersService.GetByIdAsync(id);

            if (Equals(dto, null))
            {
                return NotFound();
            }

            return dto;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateAsync([FromBody] OrderDTO dto)
        {
            await ordersService.AddAsync(dto);
            return dto;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateAsync(int id, [FromBody] OrderDTO dto)
        {
            dto.Id = id;
            await ordersService.UpdateAsync(dto);

            return dto;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult<OrderDTO>> UpdateAsync([FromBody] OrderDTO dto)
        {
            await ordersService.UpdateAsync(dto);
            return dto;
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> DeleteAsync(int id)
        {
            var dto = await ordersService.GetByIdAsync(id);

            if (Equals(dto, null))
            {
                return NotFound();
            }

            await ordersService.DeleteAsync(dto);
            return dto;
        }
    }
}

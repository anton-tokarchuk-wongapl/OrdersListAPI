using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersListAPI.DTOs;
using OrdersListAPI.Infrastructure.Validation;
using OrdersListAPI.Services.StatusesService;

namespace OrdersListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusesService statusesService;

        public StatusesController(IStatusesService statusesService)
        {
            this.statusesService = statusesService;
        }

        [ValidateModel]
        [ResponseCache(Duration = 60)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetAllAsync()
        {
            var products = await statusesService.GetAllAsync();

            return products.ToList();
        }

        [ValidateModel]
        [ResponseCache(Duration = 60)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDTO>> GetByIdAsync(int id)
        {
            var dto = await statusesService.GetByIdAsync(id);

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
        public async Task<ActionResult<StatusDTO>> CreateAsync([FromBody] StatusDTO dto)
        {
            await statusesService.AddAsync(dto);
            return dto;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<ActionResult<StatusDTO>> UpdateAsync(int id, [FromBody] StatusDTO dto)
        {
            dto.Id = id;
            await statusesService.UpdateAsync(dto);

            return dto;
        }

        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<ActionResult<StatusDTO>> UpdateAsync([FromBody] StatusDTO dto)
        {
            await statusesService.UpdateAsync(dto);
            return dto;
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusDTO>> DeleteAsync(int id)
        {
            var dto = await statusesService.GetByIdAsync(id);

            if (Equals(dto, null))
            {
                return NotFound();
            }

            await statusesService.DeleteAsync(dto);
            return dto;
        }
    }
}

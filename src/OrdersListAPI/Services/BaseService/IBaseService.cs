using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersListAPI.Services.BaseService
{
    public interface IBaseService<DTO, Entity>
        where DTO : class
        where Entity : class
    {
        Task<DTO> GetByIdAsync(int id);

        Task<IEnumerable<DTO>> GetAllAsync();

        Task AddAsync(DTO dto);

        Task UpdateAsync(DTO dto);

        Task DeleteAsync(DTO dto);
    }
}

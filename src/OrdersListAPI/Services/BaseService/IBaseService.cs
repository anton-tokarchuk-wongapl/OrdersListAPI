using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersListAPI.Services.BaseService
{
    public interface IBaseService<DTO, Entity>
        where DTO : class
        where Entity : class
    {
        Task<DTO> GetByIdAsync(int id);

        Task<IEnumerable<DTO>> GetAllAsync();

        Task<IEnumerable<DTO>> GetWhereAsync(Expression<Func<DTO, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<DTO, bool>> expression);

        Task AddAsync(DTO dto);

        Task UpdateAsync(DTO dto);

        Task DeleteAsync(DTO dto);
    }
}

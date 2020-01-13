using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using OrdersListAPI.Repositories.BaseRepository;

namespace OrdersListAPI.Services.BaseService
{
    public abstract class BaseService<DTO, Entity> : IBaseService<DTO, Entity>
        where DTO : class
        where Entity : class
    {
        protected readonly IMapper mapper;

        protected readonly IBaseRepository<Entity> baseRepository;

        public BaseService(IMapper mapper, IBaseRepository<Entity> baseRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }

        public async Task<DTO> GetByIdAsync(int id)
        {
            var entity = await baseRepository.GetByIdAsync(id);
            return mapper.Map<DTO>(entity);
        }

        public async Task<IEnumerable<DTO>> GetAllAsync()
        {
            var entities = await baseRepository.GetAllAsync();
            return mapper.Map<IEnumerable<Entity>, IEnumerable<DTO>>(entities);
        }

        public async Task AddAsync(DTO dto)
        {
            var entity = mapper.Map<Entity>(dto);
            await baseRepository.AddAsync(entity);
        }
        
        public async Task UpdateAsync(DTO dto)
        {
            var entity = mapper.Map<Entity>(dto);
            await baseRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(DTO dto)
        {
            var entity = mapper.Map<Entity>(dto);
            await baseRepository.DeleteAsync(entity);
        }
    }
}

using Tawreed.BLL.Dtos.GroupOrder;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Repository.GroupOrderRepo;

namespace Tawreed.BLL.Services.GroupOrderService
{
    public class GroupOrderService(IGroupOrderRepo repo) : IGroupOrderService
    {
        public async Task<IEnumerable<GroupOrderDto>> GetAllAsync()
        {
            var entities = await repo.GetAllAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<GroupOrderDto?> GetByIdAsync(Guid id)
        {
            var entity = await repo.GetByIdAsync(id);
            return entity?.ToDto();
        }

        public async Task<GroupOrderDto> CreateAsync(CreateGroupOrderDto dto)
        {
            var entity = dto.ToEntity();
            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task<GroupOrderDto?> UpdateAsync(UpdateGroupOrderDto dto)
        {
            var entity = await repo.GetByIdAsync(dto.Id);
            if (entity is null)
                return null;

            dto.ToEntity(entity);
            await repo.UpdateAsync(entity);
            return entity.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await repo.GetByIdAsync(id);
            if (entity is null)
                return false;

            await repo.DeleteAsync(entity);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.GroupOrderParticipants;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.BLL.Services.GroupOrderParticipants
{
    public class GroupOrderParticipantService(IMainRepo<GroupOrderParticipant> repo)
    : IGroupOrderParticipantService
    {
        public async Task<IEnumerable<GroupOrderParticipantDto>> GetAllAsync()
        {
            var entities = await repo.GetAllAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<GroupOrderParticipantDto?> GetByIdAsync(Guid id)
        {
            var entity = await repo.GetByIdAsync(id);
            return entity?.ToDto();
        }

        public async Task<GroupOrderParticipantDto> CreateAsync(CreateGroupOrderParticipantDto dto)
        {
            var entity = dto.ToEntity();
            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task<GroupOrderParticipantDto?> UpdateAsync(UpdateGroupOrderParticipantDto dto)
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

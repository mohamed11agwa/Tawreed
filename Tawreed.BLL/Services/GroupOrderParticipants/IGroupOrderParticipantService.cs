using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.GroupOrderParticipants;

namespace Tawreed.BLL.Services.GroupOrderParticipants
{
    public interface IGroupOrderParticipantService
    {
        Task<IEnumerable<GroupOrderParticipantDto>> GetAllAsync();
        Task<GroupOrderParticipantDto?> GetByIdAsync(Guid id);
        Task<GroupOrderParticipantDto> CreateAsync(CreateGroupOrderParticipantDto dto);
        Task<GroupOrderParticipantDto?> UpdateAsync(UpdateGroupOrderParticipantDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

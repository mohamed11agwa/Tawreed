using Tawreed.BLL.Dtos.GroupOrderParticipants;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class GroupOrderParticipantMappingExtensions
    {
        public static GroupOrderParticipantDto ToDto(this GroupOrderParticipant entity)
        {
            return new GroupOrderParticipantDto
            {
                Id = entity.Id,
                JoinedAt = entity.JoinedAt,
                GroupOrderId = entity.GroupOrderId,
                BuyerId = entity.BuyerId
            };
        }

        public static GroupOrderParticipant ToEntity(this CreateGroupOrderParticipantDto dto)
        {
            return new GroupOrderParticipant
            {
                Id = Guid.NewGuid(),
                GroupOrderId = dto.GroupOrderId,
                BuyerId = dto.BuyerId,
                JoinedAt = DateTime.UtcNow,
            };
        }

        public static void ToEntity(this UpdateGroupOrderParticipantDto dto, GroupOrderParticipant entity)
        {
        }
    }
}

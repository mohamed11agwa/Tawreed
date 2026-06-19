using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.GroupOrderParticipants;
using Tawreed.DAL.Enums;
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
                Status = entity.Status,
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
                Status = GroupOrderStatus.Open
            };
        }

        public static void ToEntity(this UpdateGroupOrderParticipantDto dto, GroupOrderParticipant entity)
        {
            entity.Status = dto.Status;
        }
    }
}

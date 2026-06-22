using Tawreed.BLL.Dtos.GroupOrder;
using Tawreed.DAL.Enums;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class GroupOrderMappingExtensions
    {
        public static GroupOrderDto ToDto(this GroupOrder entity)
        {
            return new GroupOrderDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DeadlineAt = entity.DeadlineAt,
                CreatorId = entity.CreatorId,
                RegionId = entity.RegionId
            };
        }

        public static GroupOrder ToEntity(this CreateGroupOrderDto dto)
        {
            return new GroupOrder
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                DeadlineAt = dto.DeadlineAt,
                CreatorId = dto.CreatorId,
                RegionId = dto.RegionId,
            };
        }

        public static void ToEntity(this UpdateGroupOrderDto dto, GroupOrder entity)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.DeadlineAt = dto.DeadlineAt;
        }
    }
}

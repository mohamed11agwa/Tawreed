using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Category;
using Tawreed.BLL.Dtos.Reigon;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class RegionMappingExtensions
    {
        // Model → Response DTO
        public static RegionResponseDto ToDto(this Region region) => new()
        {
            Id = region.Id,
            IsActive = region.IsActive,

        };

        public static IEnumerable<RegionResponseDto> ToDtoList(this IEnumerable<Region> regions)
            => regions.Select(r => r.ToDto());

        // Create DTO → Model
        public static Region ToModel(this CreateRegionDto dto) => new()
        {
            Id = Guid.NewGuid(),
            IsActive = dto.IsActive,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        // Update DTO → existing Model
        public static void ApplyUpdate(this UpdateRegionDto dto, Region region)
        {
            region.IsActive = dto.IsActive;
            region.UpdatedAt = DateTime.UtcNow;
        }
        public static void ApplyPatch(this PatchRegionDto dto, Region region)
        {
            if (dto.IsActive is not null) region.IsActive = dto.IsActive.Value;
            region.UpdatedAt = DateTime.UtcNow;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Reigon;

namespace Tawreed.BLL.Services.RegionService
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionResponseDto>> GetAllAsync();
        Task<IEnumerable<RegionResponseDto>> GetActiveAsync();
        Task<RegionResponseDto?> GetByIdAsync(Guid id);
        Task<RegionResponseDto> CreateAsync(CreateRegionDto dto);
        Task<RegionResponseDto?> UpdateAsync(Guid id, UpdateRegionDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<RegionResponseDto?> PatchAsync(Guid id, PatchRegionDto dto);

    }
}

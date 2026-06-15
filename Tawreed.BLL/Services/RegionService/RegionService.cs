using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Reigon;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Repository.RegionRepo;

namespace Tawreed.BLL.Services.RegionService
{
    public class RegionService(IRegionRepo repo) : IRegionService
    {
        private readonly IRegionRepo _repo = repo;

        public async Task<IEnumerable<RegionResponseDto>> GetAllAsync()
        {
            var regions = await _repo.GetAllAsync();
            return regions.ToDtoList();
        }

        public async Task<IEnumerable<RegionResponseDto>> GetActiveAsync()
        {
            var regions = await _repo.GetActiveRegionsAsync();
            return regions.ToDtoList();
        }

        public async Task<RegionResponseDto?> GetByIdAsync(Guid id)
        {
            var region = await _repo.GetByIdAsync(id);
            return region?.ToDto();
        }

        public async Task<RegionResponseDto> CreateAsync(CreateRegionDto dto)
        {
            var region = dto.ToModel();
            await _repo.AddAsync(region);
            await _repo.SaveChangesAsync();
            return region.ToDto();
        }

        public async Task<RegionResponseDto?> UpdateAsync(Guid id, UpdateRegionDto dto)
        {
            var region = await _repo.GetByIdAsync(id);
            if (region is null) return null;

            dto.ApplyUpdate(region);
            await _repo.UpdateAsync(region);
            await _repo.SaveChangesAsync();
            return region.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var region = await _repo.GetByIdAsync(id);
            if (region is null) return false;

            await _repo.DeleteAsync(region);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}

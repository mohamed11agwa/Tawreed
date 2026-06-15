using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Category;
using Tawreed.BLL.Dtos.Reigon;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Repository.CategoryRepo;

namespace Tawreed.BLL.Services.CategoryService
{
    public class CategoryService(ICategoryRepo repo) : ICategoryService
    {
        private readonly ICategoryRepo _repo = repo;

        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return categories.ToDtoList();
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(Guid id)
        {
            var category = await _repo.GetByIdAsync(id);
            return category?.ToDto();
        }

        public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto)
        {
            var nameTaken = await _repo.IsNameTakenAsync(dto.Name);
            if (nameTaken)
                throw new InvalidOperationException($"Category '{dto.Name}' already exists.");

            var category = dto.ToModel();
            await _repo.AddAsync(category);
            await _repo.SaveChangesAsync();
            return category.ToDto();
        }

        public async Task<CategoryResponseDto?> UpdateAsync(Guid id, UpdateCategoryDto dto)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category is null) return null;

            var nameTaken = await _repo.IsNameTakenAsync(dto.Name, excludeId: id);
            if (nameTaken)
                throw new InvalidOperationException($"Category '{dto.Name}' already exists.");

            dto.ApplyUpdate(category);
            await _repo.UpdateAsync(category);
            await _repo.SaveChangesAsync();
            return category.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category is null) return false;

            await _repo.DeleteAsync(category);
            await _repo.SaveChangesAsync();
            return true;
        }
     
    }
}

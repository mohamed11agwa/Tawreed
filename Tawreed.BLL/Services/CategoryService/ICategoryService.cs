using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Category;
using Tawreed.BLL.Dtos.Reigon;

namespace Tawreed.BLL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto?> GetByIdAsync(Guid id);
        Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto);
        Task<CategoryResponseDto?> UpdateAsync(Guid id, UpdateCategoryDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

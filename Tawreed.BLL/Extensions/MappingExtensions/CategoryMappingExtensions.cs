using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Category;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class CategoryMappingExtensions
    {
        // Model → Response DTO
        public static CategoryResponseDto ToDto(this Category category) => new()
        {
            Id = category.Id,
            Name = category.Name,
        };

        public static IEnumerable<CategoryResponseDto> ToDtoList(this IEnumerable<Category> categories)
            => categories.Select(c => c.ToDto());

        // Create DTO → Model
        public static Category ToModel(this CreateCategoryDto dto) => new()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
        };

        // Update DTO → existing Model
        public static void ApplyUpdate(this UpdateCategoryDto dto, Category category)
        {
            category.Name = dto.Name;
        }
      
    }
}

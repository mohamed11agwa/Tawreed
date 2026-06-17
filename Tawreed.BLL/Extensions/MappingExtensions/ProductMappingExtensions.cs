using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Product;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class ProductMappingExtensions
    {
        // Model → Response DTO
        public static ProductResponseDto ToDto(this Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description ?? "no description available",
            Unit = product.Unit.ToString(),
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.Name.ToString() ?? string.Empty,
        };

        public static IEnumerable<ProductResponseDto> ToDtoList(this IEnumerable<Product> products)
            => products.Select(p => p.ToDto());

        // Create DTO → Model
        public static Product ToModel(this CreateProductDto dto) => new()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name.Trim(),
            Description = dto.Description.Trim() ?? "no description available",
            Unit = dto.Unit,
            CategoryId = dto.CategoryId,
        };

        // Update DTO → existing Model
        public static void ApplyUpdate(this UpdateProductDto dto, Product product)
        {
            product.Name = dto.Name.Trim()??product.Name;
            product.Description = dto.Description.Trim() ?? product.Description??"no description available";
            product.Unit = dto.Unit ?? product.Unit;
            product.CategoryId = dto.CategoryId;
        }
        // Patch DTO → existing Model (only non-null fields)
        public static void ApplyPatch(this PatchProductDto dto, Product product)
        {
            if (dto.Name is not null) product.Name = dto.Name.Trim();
            if (dto.Description is not null) product.Description = dto.Description.Trim();
            if (dto.Unit is not null) product.Unit = dto.Unit.Value;
            if (dto.CategoryId is not null) product.CategoryId = dto.CategoryId.Value;
        }
    }

}

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
            Unit = product.Unit.ToString(),
            CategoryId = product.CategoryId,
        };

        public static IEnumerable<ProductResponseDto> ToDtoList(this IEnumerable<Product> products)
            => products.Select(p => p.ToDto());

        // Create DTO → Model
        public static Product ToModel(this CreateProductDto dto) => new()
        {
            Id = Guid.NewGuid(),
            CategoryId = dto.CategoryId,
        };

        // Update DTO → existing Model
        public static void ApplyUpdate(this UpdateProductDto dto, Product product)
        {
            product.CategoryId = dto.CategoryId;
        }
        // Patch DTO → existing Model (only non-null fields)
        public static void ApplyPatch(this PatchProductDto dto, Product product)
        {
            if (dto.CategoryId is not null) product.CategoryId = dto.CategoryId.Value;
        }
    }

}

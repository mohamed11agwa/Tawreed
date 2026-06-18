using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Product;

namespace Tawreed.BLL.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        Task<IEnumerable<ProductResponseDto>> GetByCategoryAsync(Guid categoryId);
        Task<ProductResponseDto?> GetByIdAsync(Guid id);
        Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
        Task<ProductResponseDto?> UpdateAsync(Guid id, UpdateProductDto dto);
        Task<ProductResponseDto?> PatchAsync(Guid id, PatchProductDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Product;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Repository.CategoryRepo;
using Tawreed.DAL.Repository.ProductRepo;

namespace Tawreed.BLL.Services.ProductService
{
    public class ProductService(IProductRepo productRepo, ICategoryRepo categoryRepo) : IProductService
    {
        private readonly IProductRepo _productRepo = productRepo;
        private readonly ICategoryRepo _categoryRepo = categoryRepo;

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            return products.ToDtoList();
        }

        public async Task<IEnumerable<ProductResponseDto>> GetByCategoryAsync(Guid categoryId)
        {
            var products = await _productRepo.GetByCategoryAsync(categoryId);
            return products.ToDtoList();
        }

        public async Task<ProductResponseDto?> GetByIdAsync(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return product?.ToDto();
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var categoryExists = await _categoryRepo.ExistsAsync(dto.CategoryId);
            if (!categoryExists)
                throw new KeyNotFoundException($"Category with id '{dto.CategoryId}' not found.");

            var product = dto.ToModel();
            await _productRepo.AddAsync(product);
            await _productRepo.SaveChangesAsync();
            return product.ToDto();
        }

        public async Task<ProductResponseDto?> UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null) return null;

            var categoryExists = await _categoryRepo.ExistsAsync(dto.CategoryId);
            if (!categoryExists)
                throw new KeyNotFoundException($"Category with id '{dto.CategoryId}' not found.");

            dto.ApplyUpdate(product);
            await _productRepo.UpdateAsync(product);
            await _productRepo.SaveChangesAsync();
            return product.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null) return false;

            await _productRepo.DeleteAsync(product);
            await _productRepo.SaveChangesAsync();
            return true;
        }
    }
}

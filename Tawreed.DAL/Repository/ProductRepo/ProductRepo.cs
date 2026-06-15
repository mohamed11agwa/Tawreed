using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.ProductRepo
{
    public class ProductRepo(ApplicationDbContext context) : MainRepo<Product>(context), IProductRepo
    {
        public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
            => await _dbSet
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();

        public async Task<bool> ExistsAsync(Guid id)
            => await _dbSet.AnyAsync(p => p.Id == id);
    }
}

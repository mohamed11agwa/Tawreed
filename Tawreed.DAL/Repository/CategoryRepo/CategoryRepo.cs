using Microsoft.EntityFrameworkCore;

using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.CategoryRepo
{
    public class CategoryRepo(ApplicationDbContext context) : MainRepo<Category>(context), ICategoryRepo
    {
        public async Task<bool> ExistsAsync(Guid id)
            => await _dbSet.AnyAsync(c => c.Id == id);

        public async Task<Category?> GetByNameAsync(string name)
            => await _dbSet.FirstOrDefaultAsync(c => c.Name == name);

        public async Task<bool> IsNameTakenAsync(string name, Guid? excludeId = null)
            => await _dbSet.AnyAsync(c =>
                c.Name == name &&
                (excludeId == null || c.Id != excludeId));
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.RegionRepo
{
    public class RegionRepo(ApplicationDbContext context) : MainRepo<Region>(context), IRegionRepo
    {
        public async Task<IEnumerable<Region>> GetActiveRegionsAsync()
            => await _dbSet
                .Where(r => r.IsActive)
                .OrderBy(r => r.Name)
                .ToListAsync();

        public async Task<bool> ExistsAsync(Guid id)
            => await _dbSet.AnyAsync(r => r.Id == id);

        public async Task<bool> IsNameTakenAsync(string name, Guid? excludeId = null)
            => await _dbSet.AnyAsync(r =>
                r.Name.ToLower() == name.ToLower() &&
                (excludeId == null || r.Id != excludeId));
    }
}

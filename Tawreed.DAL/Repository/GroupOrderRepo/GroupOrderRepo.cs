using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.GroupOrderRepo
{
    public class GroupOrderRepo(ApplicationDbContext context)
    : MainRepo<GroupOrder>(context), IGroupOrderRepo
    {
        public async Task<GroupOrder?> GetByIdWithDetailsAsync(Guid id)
            => await _dbSet
                .Include(g => g.Buyer)
                .Include(g => g.Region)
                .FirstOrDefaultAsync(g => g.Id == id);

        public async Task<IEnumerable<GroupOrder>> GetByRegionAsync(Guid regionId)
            => await _dbSet
                .Where(g => g.RegionId == regionId)
                .ToListAsync();
    }
}

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
        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Region>> GetActiveRegionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameTakenAsync(string name, Guid? excludeId = null)
        {
            throw new NotImplementedException();
        }
    }
}

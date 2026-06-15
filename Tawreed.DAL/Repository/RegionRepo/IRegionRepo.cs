using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.RegionRepo
{
    public interface IRegionRepo : IMainRepo<Region>
    {
        Task<IEnumerable<Region>> GetActiveRegionsAsync();
        Task<bool> ExistsAsync(Guid id);
        Task<bool> IsNameTakenAsync(string name, Guid? excludeId = null);
    }
}

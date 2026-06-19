using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.GroupOrderRepo
{
    public interface IGroupOrderRepo : IMainRepo<GroupOrder>
    {
        Task<GroupOrder?> GetByIdWithDetailsAsync(Guid id);
        Task<IEnumerable<GroupOrder>> GetByRegionAsync(Guid regionId);
    }
}

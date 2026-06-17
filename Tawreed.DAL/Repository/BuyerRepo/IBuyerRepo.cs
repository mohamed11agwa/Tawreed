using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.BuyerRepo
{
    public interface IBuyerRepo: IMainRepo<Buyer>
    {
        Task<bool> ExistsAsync(Guid userId);
    }
}

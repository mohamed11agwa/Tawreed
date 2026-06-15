using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.ProductRepo
{
    public interface IProductRepo : IMainRepo<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);
        Task<bool> ExistsAsync(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Enums;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.CategoryRepo
{
    public interface ICategoryRepo : IMainRepo<Category>
    {
        Task<bool> ExistsAsync(Guid id);
        Task<Category?> GetByNameAsync(CategoryName name);
        Task<bool> IsNameTakenAsync(CategoryName name, Guid? excludeId = null);
    }
}

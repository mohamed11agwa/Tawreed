using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Data;
using Tawreed.DAL.Enums;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.CategoryRepo
{
    public class CategoryRepo(ApplicationDbContext context) : MainRepo<Category>(context), ICategoryRepo
    {
        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameTakenAsync(string name, Guid? excludeId = null)
        {
            throw new NotImplementedException();
        }
    }
}

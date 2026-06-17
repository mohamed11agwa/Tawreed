using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.BuyerRepo
{
    public class BuyerRepo : MainRepo<Buyer>, IBuyerRepo
    {
        private readonly ApplicationDbContext _db;
        public BuyerRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> ExistsAsync(Guid userId)
        {
            return await _db.Buyers.AnyAsync(b => b.UserId == userId);
        }
    }
}

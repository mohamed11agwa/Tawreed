using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.MainRepo;

namespace Tawreed.DAL.Repository.Supplier_Repo
{
    public class SupplierRepo : MainRepo<Supplier>, ISupplierRepo
    {
        private readonly ApplicationDbContext _db;
        public SupplierRepo(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
    }
}

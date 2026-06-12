using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Models;

namespace Tawreed.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GroupOrder> GroupOrders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=mohamed\\sqlexpress;Initial Catalog=Tawreed;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}

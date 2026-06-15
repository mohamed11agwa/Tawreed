using Microsoft.EntityFrameworkCore;

using Tawreed.DAL.Models;

namespace Tawreed.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<BusinessType> BusinessTypes { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GroupOrder> GroupOrders { get; set; }
    public DbSet<GroupOrderParticipant> GroupOrderParticipants { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<SupplierProduct> SupplierProducts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TawreedDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>()
            .HasKey(b => b.UserId);

        modelBuilder.Entity<Buyer>()
            .HasOne(b => b.User)
            .WithOne(u => u.Buyer)
            .HasForeignKey<Buyer>(b => b.UserId);

        modelBuilder.Entity<Supplier>()
            .HasKey(s => s.UserId);

        modelBuilder.Entity<Supplier>()
            .HasOne(s => s.User)
            .WithOne(u => u.Supplier)
            .HasForeignKey<Supplier>(s => s.UserId);


        var CascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in CascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;


        base.OnModelCreating(modelBuilder);
    }
}

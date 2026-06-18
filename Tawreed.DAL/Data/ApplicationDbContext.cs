using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tawreed.DAL.Models;

namespace Tawreed.DAL.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TawreedDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        // ── Buyer ─────────────────────────────────────────────────────────
        modelBuilder.Entity<Buyer>()
            .HasKey(b => b.UserId);

        modelBuilder.Entity<Buyer>()
            .HasOne(b => b.User)
            .WithOne(u => u.Buyer)
            .HasForeignKey<Buyer>(b => b.UserId);

        // ── Supplier ──────────────────────────────────────────────────────
        modelBuilder.Entity<Supplier>()
            .HasKey(s => s.UserId);

        modelBuilder.Entity<Supplier>()
            .HasOne(s => s.User)
            .WithOne(u => u.Supplier)
            .HasForeignKey<Supplier>(s => s.UserId);

        // Supplier M-to-M Region
        modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Regions)
            .WithMany(r=>r.Suppliers)
            .UsingEntity(j => j.ToTable("SupplierRegions"));




        // ── ApplicationUser M-to-M Category (preferences) ────────────────
        modelBuilder.Entity<ApplicationUser>()
      .HasMany(u => u.BusinessTypes)
      .WithMany(b => b.Users)
      .UsingEntity(j => j.ToTable("UserBusinessTypes"));

        // ── SupplierProduct ───────────────────────────────────────────────
        modelBuilder.Entity<SupplierProduct>()
            .HasKey(sp => new { sp.SupplierId, sp.ProductId });

        modelBuilder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Supplier)
            .WithMany(s => s.SupplierProducts)
            .HasForeignKey(sp => sp.SupplierId);

        modelBuilder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Product)
            .WithMany(p => p.SupplierProducts)
            .HasForeignKey(sp => sp.ProductId);

        // ── GroupOrder ────────────────────────────────────────────────────
        modelBuilder.Entity<GroupOrder>()
            .HasOne(g => g.Buyer)
            .WithMany(b => b.CreatedOrders)
            .HasForeignKey(g => g.CreatorId);

        // ── GroupOrderParticipant ─────────────────────────────────────────
        modelBuilder.Entity<GroupOrderParticipant>()
            .HasOne(gop => gop.Buyer)
            .WithMany(b => b.Participations)
            .HasForeignKey(gop => gop.BuyerId);

        modelBuilder.Entity<GroupOrderParticipant>()
            .HasOne(gop => gop.GroupOrder)
            .WithMany(g => g.Participations)
            .HasForeignKey(gop => gop.GroupOrderId);

        // ── Notification ──────────────────────────────────────────────────
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId);

        // ── Global: replace all Cascade deletes with Restrict ─────────────
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tawreed.DAL.Models;

namespace Tawreed.DAL.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GroupOrder> GroupOrders { get; set; }
    public DbSet<GroupOrderParticipant> GroupOrderParticipants { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<SupplierProduct> SupplierProducts { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<GroupOrderItem> groupOrderItems { get; set; }
    public DbSet<ParticipantItem> participantItems { get; set; }
    public DbSet<PricingTier> PricingTiers { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<SupplierApprovalLogs> supplierApprovalLogs { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=MOHAMED\\SQLEXPRESS;Initial Catalog=TawreedDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        // ── Buyer ─────────────────────────────────────────────────────────
        modelBuilder.Entity<Buyer>()
            .HasKey(b => b.UserId);




        // ── SupplierProduct ───────────────────────────────────────────────

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
            .WithMany(g => g.Participants)
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

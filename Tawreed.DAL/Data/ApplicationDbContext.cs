using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tawreed.DAL.Enums;
using Tawreed.DAL.Models;

namespace Tawreed.DAL.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierApprovalLog> SupplierApprovalLogs { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GroupOrder> GroupOrders { get; set; }
    public DbSet<GroupOrderEvent> GroupOrderEvents { get; set; }
    public DbSet<GroupOrderItem> GroupOrderItems { get; set; }
    public DbSet<GroupOrderParticipant> GroupOrderParticipants { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<ParticipantItem> ParticipantItems { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Unit> Units { get; set; }



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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ApplicationUser
        builder.Entity<ApplicationUser>()
           .HasMany(u => u.Notifications)
           .WithOne(n => n.User)
           .HasForeignKey(n => n.UserId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ApplicationUser>()
            .HasMany<RefreshToken>()
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ApplicationUser>()
            .HasMany(u => u.TriggeredEvents)
            .WithOne(e => e.CreatedBy)
            .HasForeignKey(e => e.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<ApplicationUser>()
            .HasMany(u => u.ApprovalActions)
            .WithOne(l => l.Actor)
            .HasForeignKey(l => l.ActorId)
            .OnDelete(DeleteBehavior.Restrict);


        // Buyer
        builder.Entity<Buyer>()
            .HasKey(b => b.UserId);

        builder.Entity<Buyer>()
            .HasOne(b => b.User)
            .WithOne(u => u.Buyer)
            .HasForeignKey<Buyer>(b => b.UserId);

        builder.Entity<Buyer>()
            .HasOne(b => b.Region)
            .WithMany(r => r.Buyers)
            .HasForeignKey(b => b.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Supplier
        builder.Entity<Supplier>()
            .HasKey(s => s.UserId);

        builder.Entity<Supplier>()
            .HasOne(s => s.User)
            .WithOne(u => u.Supplier)
            .HasForeignKey<Supplier>(s => s.UserId);

        builder.Entity<Supplier>()
            .HasOne(s => s.Region)
            .WithMany(r => r.Suppliers)
            .HasForeignKey(s => s.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Supplier>()
            .HasMany(s => s.ApprovalLogs)
            .WithOne(l => l.Supplier)
            .HasForeignKey(l => l.SupplierUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Supplier>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Supplier>()
            .HasMany(s => s.GroupOrders)
            .WithOne(o => o.Supplier)
            .HasForeignKey(o => o.SupplierUserId)
            .OnDelete(DeleteBehavior.Restrict);


        // SupplierApprovalLog

        builder.Entity<SupplierApprovalLog>()
            .Property(l => l.Action)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);


        // Category

        builder.Entity<Category>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


        // Region

        builder.Entity<Region>()
            .HasOne(r => r.Parent)
            .WithMany(r => r.Children)
            .HasForeignKey(r => r.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Region>()
            .HasMany(r => r.GroupOrders)
            .WithOne(o => o.Region)
            .HasForeignKey(o => o.RegionId)
            .OnDelete(DeleteBehavior.Restrict);


        // Unit

        builder.Entity<Unit>()
            .HasMany(u => u.Products)
            .WithOne(p => p.Unit)
            .HasForeignKey(p => p.UnitId)
            .OnDelete(DeleteBehavior.Restrict);


        // Product

        builder.Entity<Product>()
            .HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Product>()
            .HasMany(p => p.GroupOrderItems)
            .WithOne(oi => oi.Product)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);


        // GroupOrder

        builder.Entity<GroupOrder>()
            .Property(o => o.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30)
            .HasDefaultValue(GroupOrderStatus.Draft);

        builder.Entity<GroupOrder>()
            .HasOne(o => o.Creator)
            .WithMany(b => b.CreatedOrders)
            .HasForeignKey(o => o.CreatorUserId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<GroupOrder>()
            .HasMany(o => o.Items)
            .WithOne(i => i.GroupOrder)
            .HasForeignKey(i => i.GroupOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<GroupOrder>()
            .HasMany(o => o.Participants)
            .WithOne(p => p.GroupOrder)
            .HasForeignKey(p => p.GroupOrderId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<GroupOrder>()
            .HasMany(o => o.Events)
            .WithOne(e => e.GroupOrder)
            .HasForeignKey(e => e.GroupOrderId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<GroupOrder>()
            .HasOne(o => o.Delivery)
            .WithOne(d => d.GroupOrder)
            .HasForeignKey<Delivery>(d => d.GroupOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<GroupOrder>().HasIndex(o => o.Status);
        builder.Entity<GroupOrder>().HasIndex(o => o.CreatorUserId);
        builder.Entity<GroupOrder>().HasIndex(o => o.SupplierUserId);

        // GroupOrderItem


        builder.Entity<GroupOrderItem>()
            .HasMany(i => i.ParticipantItems)
            .WithOne(pi => pi.GroupOrderItem)
            .HasForeignKey(pi => pi.GroupOrderItemId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<GroupOrderItem>().HasIndex(i => new { i.GroupOrderId, i.ProductId })
            .IsUnique();


        // GroupOrderParticipant


        builder.Entity<GroupOrderParticipant>()
            .Property(p => p.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(ParticipantStatus.Active);

        builder.Entity<GroupOrderParticipant>()
            .HasOne(p => p.Buyer)
            .WithMany(b => b.Participations)
            .HasForeignKey(p => p.BuyerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<GroupOrderParticipant>()
            .HasMany(p => p.Items)
            .WithOne(pi => pi.Participant)
            .HasForeignKey(pi => pi.ParticipantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<GroupOrderParticipant>()
            .HasIndex(p => new { p.GroupOrderId, p.BuyerUserId })
            .IsUnique();


        // ParticipantItem

        builder.Entity<ParticipantItem>()
            .HasOne(pi => pi.Product)
            .WithMany()
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ParticipantItem>()
            .HasIndex(pi => new { pi.ParticipantId, pi.ProductId })
            .IsUnique();


        // GroupOrderEvent


        builder.Entity<GroupOrderEvent>()
            .Property(e => e.EventType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(40);

        builder.Entity<GroupOrderEvent>()
            .HasIndex(e => e.GroupOrderId);



        // Delivery

        builder.Entity<Delivery>()
            .Property(d => d.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(DeliveryStatus.Pending);


        // Notification

        builder.Entity<Notification>()
                 .HasIndex(n => new { n.UserId, n.IsRead });

        // RefereshToken

        builder.Entity<RefreshToken>()
            .HasIndex(rt => rt.Token)
            .IsUnique();

        builder.Entity<RefreshToken>()
            .HasIndex(rt => rt.UserId);
    }
}

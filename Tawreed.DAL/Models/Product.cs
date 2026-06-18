using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models;

public class Product
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    [Required]
    public Guid SupplierUserId { get; set; }
    [ForeignKey(nameof(SupplierUserId))]
    public Supplier Supplier { get; set; } = null!;

    [Required]
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;


    [Required]
    public Guid UnitId { get; set; }
    public Unit Unit { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string NameAr { get; set; } = string.Empty;


    [Required]
    [MaxLength(200)]
    public string NameEn { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? DescriptionAr { get; set; }

    [MaxLength(1000)]
    public string? DescriptionEn { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasePrice { get; set; }

    public int StockQty { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public ICollection<ProductImage> Images { get; set; } = [];
    public ICollection<GroupOrderItem> GroupOrderItems { get; set; } = [];
}

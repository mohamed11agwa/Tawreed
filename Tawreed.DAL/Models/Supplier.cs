using System.ComponentModel.DataAnnotations;
using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class Supplier
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? TaxNumber { get; set; }
    public decimal RatingAvg { get; set; }
    public string? Address { get; set; }
    public bool IsApproved { get; set; }
    public Guid? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public Guid RegionId { get; set; }
    public Region Region { get; set; } = null!;
    public ApplicationUser User { get; set; } = default!;
    public  ApplicationUser? Approver { get; set; }
    public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    public ICollection<SupplierProduct> SupplierProducts { get; set; } = new HashSet<SupplierProduct>();
    public ICollection<GroupOrder> GroupOrders { get; set; } = new HashSet<GroupOrder>();

}

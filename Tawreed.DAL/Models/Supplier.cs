using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawreed.DAL.Models;

public class Supplier
{
    [Required]
    [Key]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = default!;


    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;


    [MaxLength(50)]
    public string? TaxNumber { get; set; }

    public Guid RegionId { get; set; }
    public Region Region { get; set; } = null!;


    [MaxLength(500)]
    public string? Address { get; set; }

    public bool IsApproved { get; set; } = false;
    public decimal RatingAvg { get; set; } = 0;


    //[MaxLength(100)]
    //public string? CommercialRegister { get; set; }


    //public DateTime? ApprovedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<GroupOrder> GroupOrders { get; set; } = [];
    public ICollection<SupplierApprovalLog> ApprovalLogs { get; set; } = [];
}

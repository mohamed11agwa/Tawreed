using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawreed.DAL.Models;

public class Supplier
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = null!;


    [MaxLength(50)]
    public string? TaxNumber { get; set; }


    [MaxLength(100)]
    public string? CommercialRegister { get; set; }


    public DateTime? ApprovedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    public User User { get; set; } = default!;
    public Guid RegionId { get; set; }
    public Region Region { get; set; } = default!;
    public ICollection<SupplierProduct> ?SupplierProducts { get; set; } = new HashSet<SupplierProduct>();


}

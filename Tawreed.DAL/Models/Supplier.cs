using System.ComponentModel.DataAnnotations;

namespace Tawreed.DAL.Models;

public class Supplier
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;


    [MaxLength(50)]
    public string? TaxNumber { get; set; }


    [MaxLength(100)]
    public string? CommercialRegister { get; set; }


    public DateTime? ApprovedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    public ApplicationUser User { get; set; } = default!;
    public ICollection<Region> Regions { get; set; } = new HashSet<Region>();
    public ICollection<SupplierProduct>? SupplierProducts { get; set; } = new HashSet<SupplierProduct>();



}

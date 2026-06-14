using System.ComponentModel.DataAnnotations;

using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    [Required]
    [MaxLength(20)]
    public UnitOfMeasure Unit { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public ICollection<SupplierProduct> SupplierProducts { get; set; } = new HashSet<SupplierProduct>();
}

using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }    
    
    public Guid? CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public Guid? UnitId { get; set; }
    public Unit Unit { get; set; } = default!;
    public ICollection<SupplierProduct> SupplierProducts { get; set; } = new HashSet<SupplierProduct>();

}

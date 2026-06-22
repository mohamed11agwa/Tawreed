using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class SupplierProduct : BaseAuditableEntity
{
    public decimal BasePrice { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = default!;

    public virtual ICollection<PricingTier> PricingTiers { get; set; } = new HashSet<PricingTier>();
    public virtual ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>();
}

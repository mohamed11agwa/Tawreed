using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class PricingTier : BaseEntity
{
    public int MinQty { get; set; }
    public int? MaxQty { get; set; }
    public decimal UnitPrice { get; set; }

    public Guid SupplierProductId { get; set; }
    public SupplierProduct SupplierProduct { get; set; } = null!;
}

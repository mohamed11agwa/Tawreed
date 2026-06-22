using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class ProductImage : BaseEntity
{
    public int SortOrder { get; set; }
    public bool IsCover { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Guid SupplierProductId { get; set; }
    public SupplierProduct SupplierProduct { get; set; } = default!;


}

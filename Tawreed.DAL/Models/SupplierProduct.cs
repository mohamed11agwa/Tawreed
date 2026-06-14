namespace Tawreed.DAL.Models;

public class SupplierProduct
{
    public Guid Id{ get; set; }
    public decimal BasePrice { get; set; }
    public decimal? StockQuantity { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = default!;
}

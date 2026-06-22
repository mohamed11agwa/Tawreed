
using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class Delivery : BaseAuditableEntity
{
    public Guid InvoiceId { get; set; }
    public Guid GroupOrderId { get; set; }
    public Guid SupplierId { get; set; }
    public string Status { get; set; } = null!;

    public DateTime ScheduledAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string ShippingAddress { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;
    public virtual GroupOrder GroupOrder { get; set; } = null!;
    public virtual Supplier Supplier { get; set; } = null!;
}

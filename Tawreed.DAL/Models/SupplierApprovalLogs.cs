using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class SupplierApprovalLogs : BaseAuditableEntity
{
    public string Action { get; set; } = string.Empty;
    public string? Reason { get; set; }
    public Guid? SupplierId { get; set; }
    public Supplier Supplier { get; set; } = default!;
}

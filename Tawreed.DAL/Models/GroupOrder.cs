using System.ComponentModel.DataAnnotations;
using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class GroupOrder : BaseAuditableEntity
{

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    public string OrderNumber { get; set; } = null!;
    public string? Notes { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = string.Empty;
    public DateTime DeadlineAt { get; set; }
    public DateTime? ClosedAt { get; set; }


    public Guid CreatorId { get; set; }
    public Buyer Buyer { get; set; } = default!;

    public Guid RegionId { get; set; }
    public Region Region { get; set; } = default!;

    public Guid? SupplierId { get; set; }
    public Supplier Supplier { get; set; } = default!;
    public ICollection<GroupOrderItem> Items { get; set; } = new HashSet<GroupOrderItem>();
    public ICollection<GroupOrderParticipant> Participants { get; set; } = new HashSet<GroupOrderParticipant>();
}

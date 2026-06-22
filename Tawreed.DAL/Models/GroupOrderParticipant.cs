using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class GroupOrderParticipant : BaseEntity
{
    public string Status { get; set; } = "Joined";
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CancelledAt { get; set; }

    public Guid BuyerId { get; set; }
    public Buyer Buyer { get; set; } = default!;

    public Guid GroupOrderId { get; set; }
    public GroupOrder GroupOrder { get; set; } = default!;

    public virtual ICollection<ParticipantItem> Items { get; set; } = new HashSet<ParticipantItem>();


}

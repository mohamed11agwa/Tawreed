using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models;

public class GroupOrderParticipant
{
    public Guid Id { get; set; }

    public ParticipantStatus Status { get; set; } = ParticipantStatus.Active;
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CancelledAt { get; set; }


    [Required]
    public Guid GroupOrderId { get; set; }
    public GroupOrder GroupOrder { get; set; } = null!;

    [Required]
    public Guid BuyerUserId { get; set; }
    [ForeignKey(nameof(BuyerUserId))]
    public Buyer Buyer { get; set; } = null!;

    public ICollection<ParticipantItem> Items { get; set; } = [];


}

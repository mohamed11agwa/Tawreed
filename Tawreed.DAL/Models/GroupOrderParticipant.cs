using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models;

public class GroupOrderParticipant
{
    public Guid Id { get; set; }
    public GroupOrderStatus Status { get; set; } =GroupOrderStatus.Open ;
    public DateTime JoinedAt { get; set; }


    public Guid GroupOrderId { get; set; }
    public GroupOrder GroupOrder { get; set; } = default!;

    public Guid BuyerId { get; set; }
    public Buyer Buyer { get; set; } = default!;
}

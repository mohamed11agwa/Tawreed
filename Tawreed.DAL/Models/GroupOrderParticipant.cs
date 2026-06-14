namespace Tawreed.DAL.Models;

public class GroupOrderParticipant
{
    public Guid Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime JoinedAt { get; set; }


    public Guid GroupOrderId { get; set; }
    public GroupOrder GroupOrder { get; set; } = default!;

    public Guid BuyerId { get; set; }
    public Buyer Buyer { get; set; } = default!;
}

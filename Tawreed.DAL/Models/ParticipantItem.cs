using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models
{
    public class ParticipantItem : BaseEntity
    {

        public int Quantity { get; set; }
        public decimal UnitPriceAtJoin { get; set; }
        public decimal? FinalUnitPrice { get; set; }
        public decimal? LineTotal { get; set; }

        public Guid ParticipantId { get; set; }
        public Guid GroupOrderItemId { get; set; }

        public GroupOrderParticipant Participant { get; set; } = null!;
        public GroupOrderItem GroupOrderItem { get; set; } = null!;
    }
}
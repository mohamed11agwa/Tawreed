using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; } = null!;
        public Guid GroupOrderId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid ParticipantId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string PaymentStatus { get; set; } = null!;
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
        public string ShippingAddress { get; set; } = null!;

        public virtual GroupOrder GroupOrder { get; set; } = null!;
        public virtual Buyer Buyer { get; set; } = null!;
        public virtual GroupOrderParticipant Participant { get; set; } = null!;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tawreed.DAL.Models
{
    public class ParticipantItem
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid ParticipantId { get; set; }
        public GroupOrderParticipant Participant { get; set; } = null!;


        [Required]
        public Guid GroupOrderItemId { get; set; }
        public GroupOrderItem GroupOrderItem { get; set; } = null!;

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}

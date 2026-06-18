using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 



        [Required]
        public Guid GroupOrderId { get; set; }
        public GroupOrder GroupOrder { get; set; } = null!;

        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

        [MaxLength(500)]
        public string? Address { get; set; }

        public DateTime? ScheduledAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        [MaxLength(1000)]
        public string? TrackingNotes { get; set; }

    }
}

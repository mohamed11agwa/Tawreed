using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class GroupOrderEvent
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid GroupOrderId { get; set; }
        public GroupOrder GroupOrder { get; set; } = null!;

        public GroupOrderEventType EventType { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public Guid CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; } = null!;
        
    }
}

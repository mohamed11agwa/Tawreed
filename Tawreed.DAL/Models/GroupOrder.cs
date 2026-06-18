using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class GroupOrder
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(2000)]

        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? ClosedAt { get; set; }

        [Required]
        [MaxLength(20)]
        public GroupOrderStatus Status { get; set; } = GroupOrderStatus.Draft;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalOrderValue { get; set; }


        [Required]
        public Guid SupplierUserId { get; set; }
        public Supplier? Supplier { get; set; }


        public Guid CreatorId { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public Buyer? Buyer { get; set; }

        [Required]
        public Guid RegionId { get; set; }
        public Region? Region { get; set; }

        public Delivery? Delivery { get; set; }

        public ICollection<GroupOrderParticipant> Participants { get; set; } = [];
        public ICollection<GroupOrderItem> Items { get; set; } = [];
        public ICollection<GroupOrderEvent> Events { get; set; } = [];
    }
}

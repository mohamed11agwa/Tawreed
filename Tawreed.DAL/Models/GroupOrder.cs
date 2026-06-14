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
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime DeadlineAt { get; set; }

        [Required]
        [MaxLength(20)]
        public GroupOrderStatus Status { get; set; } = GroupOrderStatus.Open;




        public Guid CreatorId { get; set; }
        public Buyer Buyer { get; set; } = default!;

        public Guid RegionId { get; set; }
        public Region Region { get; set; } = default!;
        public ICollection<GroupOrderParticipant> Participations { get; set; } = [];

    }
}

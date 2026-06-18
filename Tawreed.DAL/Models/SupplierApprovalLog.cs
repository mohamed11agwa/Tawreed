using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class SupplierApprovalLog
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid SupplierUserId { get; set; }
        [ForeignKey(nameof(SupplierUserId))]
        public Supplier Supplier { get; set; } = null!;


        public SupplierApprovalAction Action { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        public Guid ActorId { get; set; }
        [ForeignKey(nameof(ActorId))]
        public ApplicationUser Actor { get; set; } = null!;

    }
}

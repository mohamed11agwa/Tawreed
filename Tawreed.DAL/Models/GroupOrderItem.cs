using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata;
using System.Text;

namespace Tawreed.DAL.Models
{
    public class GroupOrderItem
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public Guid GroupOrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public int TargetQuantity { get; set; }
        public int CurrentQuntity { get; set; } = 0;

        [Column(TypeName="decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal CurrentPrice { get; set; }

        public GroupOrder GroupOrder { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public ICollection<ParticipantItem> ParticipantItems { get; set; } = [];

    }
}

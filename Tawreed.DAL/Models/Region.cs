using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tawreed.DAL.Models
{
    public class Region
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameAr { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string NameEn { get; set; } = string.Empty;

        public Guid? ParentId { get; set; }
        public Region? Parent { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Region> Children { get; set; } = [];
        public ICollection<Buyer> Buyers { get; set; } = [];
        public ICollection<Supplier> Suppliers { get; set; } = [];
        public ICollection<GroupOrder> GroupOrders { get; set; } = [];


    }
}

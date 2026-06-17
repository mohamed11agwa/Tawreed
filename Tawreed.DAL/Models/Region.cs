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
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Buyer> Buyers { get; set; } = new HashSet<Buyer>();
        public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
        public ICollection<GroupOrder> GroupOrders { get; set; } = new HashSet<GroupOrder>();


    }
}

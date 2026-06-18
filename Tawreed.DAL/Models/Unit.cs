using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tawreed.DAL.Models
{
    public class Unit
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameAr { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string NameEn { get; set; } = string.Empty;


        [Required]
        [MaxLength(20)]
        public string Symbol { get; set; } = string.Empty;


        public ICollection<Product> Products { get; set; } = [];
    }
}

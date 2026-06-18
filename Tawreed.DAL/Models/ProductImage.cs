using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tawreed.DAL.Models
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Url { get; set; } = string.Empty;
        public bool IsCover { get; set; } = false;

    }
}

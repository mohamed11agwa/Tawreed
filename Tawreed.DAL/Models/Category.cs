using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameAr { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string NameEn { get; set; } = string.Empty;

        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }

        [MaxLength(500)]
        public string? IconUrl { get; set; }
        public int SortOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public ICollection<Category> Children { get; set; } = [];
        public ICollection<Supplier> Suppliers { get; set; } = [];
        public ICollection<Product> Products { get; set; } = [];
    }
}

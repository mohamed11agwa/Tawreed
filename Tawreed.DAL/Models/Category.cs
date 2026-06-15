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

        [Required]
        public CategoryName Name { get; set; }
        public ICollection<Product> ?Products { get; set; } = new HashSet<Product>();



    }
}

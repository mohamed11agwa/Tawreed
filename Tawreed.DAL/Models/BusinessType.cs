using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class BusinessType
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}

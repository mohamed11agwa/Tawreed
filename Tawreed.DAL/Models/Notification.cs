using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;


        [Required]
        [MaxLength(200)]
        public string TitleAr { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string TitleEn { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? MessageAr { get; set; }

        [MaxLength(1000)]
        public string? MessageEn { get; set; }

        [MaxLength(50)]
        public string Type { get; set; } = "General";

        public bool IsRead { get; set; } = false;

    }
}

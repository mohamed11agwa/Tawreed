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


        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;


        [Required]
        [MaxLength(30)]
        public NotificationType Type { get; set; }


        public string? Body { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        public Guid GroupOrderId { get; set; }
        public GroupOrder? GroupOrder { get; set; }


    }
}

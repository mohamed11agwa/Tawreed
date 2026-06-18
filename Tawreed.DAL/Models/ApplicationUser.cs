using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    public UserStatus Status { get; set; } = UserStatus.Active;
    public string? AvatarUrl { get; set; }

    [Required]
    [MaxLength(2)]
    public string PreferredLang { get; set; } = "ar";
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }


    public Buyer? Buyer { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<Notification> Notifications { get; set; } = [];
    public ICollection<GroupOrderEvent> TriggeredEvents { get; set; } = [];
    public ICollection<SupplierApprovalLog> ApprovalActions { get; set; } = [];
}

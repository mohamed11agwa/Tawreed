using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tawreed.DAL.Models;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    public string Status { get; set; } = null!;
    public DateTime? LastLoginAt { get; set; }
    [Required]
    [MaxLength(2)]
    public string PreferredLang { get; set; } = "ar";

    [MaxLength(500)]
    public string? AvatarUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }


    // Navigation
    public Buyer? Buyer { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}

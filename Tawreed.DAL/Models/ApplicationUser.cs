using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tawreed.DAL.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    public string PreferredLang { get; set; } = "ar";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }


    // Navigation
    public Buyer? Buyer { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<BusinessType> BusinessTypes { get; set; }= new HashSet<BusinessType>();
    public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();

    public List<RefreshToken> RefreshTokens { get; set; } = [];
}

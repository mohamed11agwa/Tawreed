using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawreed.DAL.Models;

public class Buyer
{
    [Required]
    [Key]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;


    [Required]
    [MaxLength(200)]
    public string BusinessName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string? BusinessType { get; set; } 


    [MaxLength(50)]
    public string? TaxNumber { get; set; }

    [Required]
    [MaxLength(500)]
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public Guid RegionId { get; set; }
    public Region Region { get; set; } = null!;

    public ICollection<GroupOrder> CreatedOrders { get; set; } = new HashSet<GroupOrder>();
    public ICollection<GroupOrderParticipant> Participations { get; set; } = [];
    
}

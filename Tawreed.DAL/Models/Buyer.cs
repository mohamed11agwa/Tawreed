using System.ComponentModel.DataAnnotations;
using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class Buyer
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(200)]
    public string BusinessName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string BusinessType { get; set; } = string.Empty;


    [MaxLength(50)]
    public string? TaxNumber { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }
    public decimal RatingAvg { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ApplicationUser User { get; set; } = default!;
    public Guid? RegionId { get; set; }
    public Region Region { get; set; } = default!;
    public ICollection<GroupOrder> CreatedOrders { get; set; } = new HashSet<GroupOrder>();
    public ICollection<GroupOrderParticipant> Participations { get; set; } = new HashSet<GroupOrderParticipant>();
    
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawreed.DAL.Models;

public class Buyer
{
    public Guid UserId { get; set; }


    [Required]
    [MaxLength(200)]
    public string BusinessName { get; set; } = string.Empty;

    //[Required]
    //[MaxLength(20)]
    //public string BusinessType { get; set; } 


    [MaxLength(50)]
    public string? TaxNumber { get; set; }

    [Required]
    [MaxLength(500)]
    public string Address { get; set; } = string.Empty;

    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    public User User { get; set; } = default!;
    public Guid RegionId { get; set; }
    public Region Region { get; set; } = default!;

    public ICollection<Category> Categories { get; set; } = new HashSet<Category>();

    public ICollection<GroupOrder> CreatedOrders { get; set; } = new HashSet<GroupOrder>();
    public ICollection<GroupOrderParticipant> Participations { get; set; } = [];
}

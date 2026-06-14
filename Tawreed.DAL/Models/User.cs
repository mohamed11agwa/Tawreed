using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tawreed.DAL.Models;

public class User
{
    public Guid ID { get; set; }


    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;



    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;



    [Required]
    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;


    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;


    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "pending";


    [Required]
    [MaxLength(2)]
    public string PreferredLang { get; set; } = "ar";

    public DateTime? LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }





    public Buyer? Buyer { get; set; } = default!;
    public Supplier? Supplier { get; set; } = default!;
    public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();

}

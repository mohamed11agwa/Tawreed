using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tawreed.DAL.Common;
using Tawreed.DAL.Enums;

namespace Tawreed.DAL.Models;

public class Notification : BaseAuditableEntity
{

    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public NotificationType Type { get; set; }

    public string? Body { get; set; }

    public bool IsRead { get; set; } = false;

    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = default!;

    public Guid GroupOrderId { get; set; }
    public GroupOrder? GroupOrder { get; set; }


}

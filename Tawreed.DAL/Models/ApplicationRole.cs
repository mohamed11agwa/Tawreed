using Microsoft.AspNetCore.Identity;

namespace Tawreed.DAL.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public bool IsDeleted { get; set; }
}

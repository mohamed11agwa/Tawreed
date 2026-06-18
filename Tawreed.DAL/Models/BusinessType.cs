using System.ComponentModel.DataAnnotations;

namespace Tawreed.DAL.Models
{
    public class BusinessType
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
    }
}

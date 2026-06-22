using System.ComponentModel.DataAnnotations;
using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models
{
    public class Region : BaseAuditableEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public Guid? ParentId { get; set; }

        public Region? ParentRegion { get; set; } = default!;
        public ICollection<Region> ChildrenRegions { get; set; } = new HashSet<Region>();

        public ICollection<Buyer> Buyers { get; set; } = new HashSet<Buyer>();
        public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
        public ICollection<GroupOrder> GroupOrders { get; set; } = new HashSet<GroupOrder>();
    }
}

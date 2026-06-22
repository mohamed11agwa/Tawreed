using System.ComponentModel.DataAnnotations;
using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class Category : BaseSoftDeletableEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? IconUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public int SortOrder { get; set; }

    public Guid? ParentId { get; set; }

    public Category? ParentCategory { get; set; }

    public ICollection<Category> ChildrenCategories { get; set; } = new HashSet<Category>();
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();

}

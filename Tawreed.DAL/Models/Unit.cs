using Tawreed.DAL.Common;

namespace Tawreed.DAL.Models;

public class Unit : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
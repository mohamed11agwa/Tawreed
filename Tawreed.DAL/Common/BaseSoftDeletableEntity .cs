namespace Tawreed.DAL.Common;

public abstract class BaseSoftDeletableEntity : BaseAuditableEntity
{
    public bool IsDeleted { get; set; }
}

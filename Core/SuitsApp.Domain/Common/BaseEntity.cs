namespace SuitsApp.Domain.Common;
public abstract class BaseEntity
{
    // public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}

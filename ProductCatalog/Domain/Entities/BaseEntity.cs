namespace ProductCatalog.Core.Domain.Common;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedByUserId { get; set; }
}

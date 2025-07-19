using ProductCatalog.Core.Domain.Common;

namespace ProductCatalog.Core.Domain.Entities;

public class ProductHistory:BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string OldName { get; set; } = string.Empty;
    public decimal OldPrice { get; set; }
    public DateTime OldStartDate { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string UpdatedByUserId { get; set; } = string.Empty;

    // Navigation
    public Product? Product { get; set; }
}

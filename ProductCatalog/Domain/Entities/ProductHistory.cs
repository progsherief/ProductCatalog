using Domain.Common;

namespace ProductCatalog.Core.Domain.Entities;

public class ProductHistory:BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public string OldName { get; set; } = default!;
    public decimal OldPrice { get; set; }
    public DateTime OldStartDate { get; set; }


    public DateTime UpdatedAt { get; set; }
    public string? UpdatedByUserId { get; set; }
}

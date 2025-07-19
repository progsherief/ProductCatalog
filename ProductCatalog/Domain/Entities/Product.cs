using Domain.Common;

namespace ProductCatalog.Core.Domain.Entities;

public class Product:BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public int DurationInDays { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;

    public string ImagePath { get; set; } = default!;

    // ✅ Navigation
    public ICollection<ProductHistory> History { get; set; } = new List<ProductHistory>();
}

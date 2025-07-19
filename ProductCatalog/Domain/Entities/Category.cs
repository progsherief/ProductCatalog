using Domain.Common;

namespace ProductCatalog.Core.Domain.Entities;

public class Category:BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}

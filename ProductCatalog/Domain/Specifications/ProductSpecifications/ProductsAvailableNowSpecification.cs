

namespace Domain.Specifications.ProductSpecifications;

public class ProductsAvailableNowSpecification:BaseSpecification<Product>
{
    public ProductsAvailableNowSpecification()
    {
        var now = DateTime.UtcNow;

        AddCriteria(p =>
            p.StartDate <= now &&
            now <= p.StartDate.AddDays(p.DurationInDays));

        AddInclude(p => p.Category); 
        ApplyOrderByDescending(p => p.CreatedAt);
    }
}

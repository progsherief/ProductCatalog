namespace Domain.Specifications.ProductSpecifications;

public class ProductsByCategorySpecification:BaseSpecification<Product>
{
    public ProductsByCategorySpecification(Guid categoryId)
    {
        AddCriteria(p => p.CategoryId == categoryId);
        AddInclude(p => p.Category);
        ApplyOrderByDescending(p => p.CreatedAt);
    }
}

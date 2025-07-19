namespace Domain.Specifications.ProductSpecifications;

public class ProductsByNameSpecification:BaseSpecification<Product>
{
    public ProductsByNameSpecification(string name)
    {
        var lowerName = name.ToLower();

        AddCriteria(p => p.Name.ToLower().Contains(lowerName));
        AddInclude(p => p.Category);
        ApplyOrderBy(p => p.Name);
    }
}

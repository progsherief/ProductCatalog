
using Services.ServiceAbstractions;

namespace Services;

public class ProductService:IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _unitOfWork.Products.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> GetAvailableNowAsync()
    {
        var spec = new ProductsAvailableNowSpecification();
        return await _unitOfWork.Products.GetAllAsync(spec);
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
    {
        var spec = new ProductsByCategorySpecification(categoryId);
        return await _unitOfWork.Products.GetAllAsync(spec);
    }

    public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        var spec = new ProductsByNameSpecification(name);
        return await _unitOfWork.Products.GetAllAsync(spec);
    }
}

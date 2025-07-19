


namespace Services.ServiceAbstractions;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> GetAvailableNowAsync();
    Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
}

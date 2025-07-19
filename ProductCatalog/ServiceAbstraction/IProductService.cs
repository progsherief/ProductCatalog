using Shared.ViewModels.Product;

namespace ServiceAbstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAvailableProductsAsync();
        Task CreateProductAsync(ProductCreateViewModel model,string imagePath,string userId);
        Task<ProductViewModel> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
        Task<IEnumerable<ProductViewModel>> GetByCategoryAsync(Guid categoryId);
        Task<IEnumerable<ProductViewModel>> SearchByNameAsync(string searchTerm);
    }
}

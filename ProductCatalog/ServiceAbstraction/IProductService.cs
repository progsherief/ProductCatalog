using Shared.ViewModels.Product;

namespace ProductCatalog.Core.Contracts
{
    public interface IProductService
    {
        Task AddProductAsync(ProductCreateViewModel model,string userId);
        Task EditProductAsync(ProductEditViewModel model,string userId);
        Task DeleteAsync(Guid id);
        Task<List<ProductViewModel>> GetAllAsync();
        Task<List<ProductViewModel>> GetAvailableProductsAsync();
        Task<List<ProductViewModel>> SearchByNameAsync(string name);
        Task<List<ProductViewModel>> FilterByCategoryAsync(Guid categoryId);
    }
}

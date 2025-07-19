using Shared.ViewModels.Category;

namespace ServiceAbstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
    }
}

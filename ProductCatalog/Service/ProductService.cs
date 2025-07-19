using AutoMapper;
using ServiceAbstractions;
using Shared.ViewModels.Product;

namespace Services.Implementations
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAvailableProductsAsync()
        {
            var spec = new ProductsAvailableNowSpecification();
            var products = await _unitOfWork.ProductRepository.GetAllAsync(spec);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<ProductViewModel> GetByIdAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task CreateProductAsync(ProductCreateViewModel model,string imagePath,string userId)
        {
            var product = _mapper.Map<Product>(model);
            product.ImagePath = imagePath;
            product.CreatedByUserId = userId;
            product.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();            
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if(product is null) return;

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetByCategoryAsync(Guid categoryId)
        {
            var spec = new ProductsByCategorySpecification(categoryId);
            var products = await _unitOfWork.ProductRepository.GetAllAsync(spec);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<IEnumerable<ProductViewModel>> SearchByNameAsync(string searchTerm)
        {
            var spec = new ProductsByNameSpecification(searchTerm);
            var products = await _unitOfWork.ProductRepository.GetAllAsync(spec);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}


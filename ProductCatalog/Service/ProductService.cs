using AutoMapper;
using Domain.Specifications.ProductSpecifications;
using ProductCatalog.Core.Contracts;
using ProductCatalog.Core.Domain.Entities;
using Shared.ViewModels.Product;

namespace ProductCatalog.Services
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

        public async Task AddProductAsync(ProductCreateViewModel model,string userId)
        {
            var product = _mapper.Map<Product>(model);
            product.CreatedAt = DateTime.UtcNow;
            product.CreatedByUserId = userId;
            product.ImagePath = model.ImagePath;

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditProductAsync(ProductEditViewModel model,string userId)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(model.Id);
            if(existingProduct == null)
                throw new Exception("Product not found");

            var history = new ProductHistory
            {
                ProductId = existingProduct.Id,
                OldName = existingProduct.Name,
                OldPrice = existingProduct.Price,
                OldStartDate = existingProduct.StartDate,
                UpdatedAt = DateTime.UtcNow,
                UpdatedByUserId = userId
            };

            existingProduct.Name = model.Name;
            existingProduct.StartDate = model.StartDate;
            existingProduct.DurationInDays = model.DurationInDays;
            existingProduct.Price = model.Price;
            existingProduct.CategoryId = model.CategoryId;
            existingProduct.ImagePath = model.ImagePath;

            await _unitOfWork.ProductHistoryRepository.AddAsync(history);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if(product == null) throw new Exception("Product not found");

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public async Task<List<ProductViewModel>> GetAvailableProductsAsync()
        {
            var spec = new ProductsAvailableNowSpecification();
            var products = await _unitOfWork.ProductRepository.GetBySpecificationAsync(spec);
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public async Task<List<ProductViewModel>> SearchByNameAsync(string name)
        {
            var spec = new ProductsByNameSpecification(name);
            var products = await _unitOfWork.ProductRepository.GetBySpecificationAsync(spec);
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public async Task<List<ProductViewModel>> FilterByCategoryAsync(Guid categoryId)
        {
            var spec = new ProductsByCategorySpecification(categoryId);
            var products = await _unitOfWork.ProductRepository.GetBySpecificationAsync(spec);
            return _mapper.Map<List<ProductViewModel>>(products);
        }
    }
}

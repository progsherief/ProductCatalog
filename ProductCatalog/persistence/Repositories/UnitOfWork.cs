
using ProductCatalog.Infrastructure.Repositories;

namespace Infrastructure.Persistence;

public class UnitOfWork:IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private IGenericRepository<Product> _productRepository;
    private IGenericRepository<Category> _categoryRepository;
    private IGenericRepository<ProductHistory> _productHistoryRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Product> ProductRepository
        => _productRepository ??= new GenericRepository<Product>(_context);

    public IGenericRepository<Category> CategoryRepository
        => _categoryRepository ??= new GenericRepository<Category>(_context);

    public IGenericRepository<ProductHistory> ProductHistoryRepository
        => _productHistoryRepository ??= new GenericRepository<ProductHistory>(_context);

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public void Dispose()
        => _context.Dispose();
}

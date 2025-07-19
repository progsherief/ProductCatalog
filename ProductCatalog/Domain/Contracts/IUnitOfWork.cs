
namespace Domain.Contracts;

public interface IUnitOfWork:IDisposable
{
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<Category> CategoryRepository { get; }
    IGenericRepository<ProductHistory> ProductHistoryRepository { get; }

    Task<int> SaveChangesAsync();
}

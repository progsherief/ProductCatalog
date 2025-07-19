
namespace Domain.Contracts;

public interface IUnitOfWork:IDisposable
{
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Category> Categories { get; }
    IGenericRepository<ProductHistory> ProductHistories { get; }

    Task<int> SaveChangesAsync();
}

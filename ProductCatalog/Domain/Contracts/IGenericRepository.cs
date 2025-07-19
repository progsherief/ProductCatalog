using Domain.Specifications;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(ISpecification<T> spec); // 

    Task<T> GetFirstOrDefaultAsync(ISpecification<T> spec);  // 

    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}

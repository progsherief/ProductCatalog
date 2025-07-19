
namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<T>:IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(ISpecification<T> spec)
    {
        var query = SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(),spec);
        return await query.ToListAsync();
    }

    public async Task<T> GetFirstOrDefaultAsync(ISpecification<T> spec)
    {
        var query = SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(),spec);
        return await query.FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}

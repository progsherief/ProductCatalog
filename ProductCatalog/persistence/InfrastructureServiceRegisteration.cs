


namespace Infrastructure.Persistence;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register Generic Repository
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped<IProductService,ProductService>();
        // Register Unit of Work
        //services.AddScoped<IUnitOfWork,UnitOfWork>();

        return services;
    }
}




using ServiceAbstractions;
using Services.Implementations;
using Services.Mappings;

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
        //services.AddScoped<IProductService,ProductService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Register Unit of Work
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
        services.AddScoped<ICategoryService,CategoryService>();
        return services;
    }
}

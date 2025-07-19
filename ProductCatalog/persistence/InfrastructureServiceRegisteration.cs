using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalog.Core.Domain.Contracts;
using ProductCatalog.Infrastructure.Persistence.Repositories;
using ProductCatalog.Infrastructure.Persistence;

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

        // Register Unit of Work
        //services.AddScoped<IUnitOfWork,UnitOfWork>();

        return services;
    }
}

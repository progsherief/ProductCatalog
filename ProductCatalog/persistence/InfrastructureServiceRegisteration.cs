using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalog.Core.Domain.Contracts;
using ProductCatalog.Infrastructure.Persistence.Repositories;
using ProductCatalog.Infrastructure.Persistence;
using Domain.Contracts;

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
        // Register Unit of Work
        //services.AddScoped<IUnitOfWork,UnitOfWork>();

        return services;
    }
}

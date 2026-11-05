using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChillTechnologies.Domain.Interfaces;
using ChillTechnologies.Infrastructure.Context;
using ChillTechnologies.Infrastructure.Repositories;

namespace ChillTechnologies.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

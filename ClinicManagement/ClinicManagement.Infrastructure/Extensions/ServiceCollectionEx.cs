using ClinicManagement.Core.Interfaces;
using ClinicManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagement.Infrastructure.Extensions;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddScoped<IAppDbContext, AppDbContext>();

        var connectionString = configuration.GetConnectionString("SQLConnection");
        services.AddDbContext<AppDbContext>(options =>
        {
            options
#if DEBUG
                .EnableSensitiveDataLogging()
#endif
                .UseSqlServer(connectionString);
        });
        return services;
    }
}
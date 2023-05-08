using System.Reflection;
using ClinicManagement.Core.Mapping;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagement.Core.Extensions;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        MappingProfile.Init();
         TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
         services.AddMediatR(p => p.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
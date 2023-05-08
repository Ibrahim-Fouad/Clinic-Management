using System.Reflection;
using MediatR.NotificationPublishers;

namespace ClinicManagement.API.Extensions;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.NotificationPublisher = new TaskWhenAllPublisher();
        });
        return services;
    }
}
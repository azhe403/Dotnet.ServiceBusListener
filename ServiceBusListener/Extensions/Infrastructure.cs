using Azure.Messaging.ServiceBus;

namespace ServiceBusListener.Extensions;

public static class Infrastructure
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddHostedService<RndHostedService>();
        services.AddSingleton<RndProcessor>();
        services.AddSingleton<ServiceBusClient>(provider =>
        {
            var config = provider.GetRequiredService<IConfiguration>();
            var serviceBusConnectionConfig = config.GetRequiredSection("ServiceBusConnection");

            return new ServiceBusClient(serviceBusConnectionConfig.Value);
        });

        return services;
    }
}
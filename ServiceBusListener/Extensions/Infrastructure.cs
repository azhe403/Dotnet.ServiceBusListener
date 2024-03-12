using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace ServiceBusListener.Extensions;

public static class Infrastructure
{
    public static IServiceCollection ConfigureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsWithValidateOnStart<ServiceBusSetting>().Bind(configuration.GetSection(ServiceBusSetting.SectionName)).ValidateDataAnnotations();

        return services;
    }

    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddHostedService<RndHostedService>();
        services.AddSingleton<RndProcessor>();
        services.AddSingleton<ServiceBusClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<ServiceBusSetting>>().Value;

            return new ServiceBusClient(options.Connection);
        });

        return services;
    }
}
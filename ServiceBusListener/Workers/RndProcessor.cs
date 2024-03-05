using System.Reflection;
using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace ServiceBusListener.Workers;

public class RndProcessor(ILogger<RndProcessor> logger, IServiceProvider serviceProvider)
{
    public async Task ProcessorOnProcessErrorAsync(ProcessErrorEventArgs args)
    {
        logger.LogError(args.Exception, "Error when Processing Message");

        await Task.Delay(0);
    }

    public async Task ProcessorOnProcessMessageAsync(ProcessMessageEventArgs args)
    {
        logger.LogInformation("Receiving Message from {FullyQualifiedNamespace}/{EntityPath}", args.FullyQualifiedNamespace, args.EntityPath);

        var request = JsonSerializer.Deserialize<ServiceBusRequest>(args.Message.Body);

        var method = Assembly.GetEntryAssembly()?.GetTypes()
            .SelectMany(x => x.GetMethods())
            .FirstOrDefault(info => info.GetCustomAttribute<ActionAttribute>()?.Name == request?.action);

        if (method == null)
        {
            logger.LogDebug("No action found with name {ActionName}", request?.action);
            return;
        }

        // invoke method here

        await Task.Delay(0);
    }
}
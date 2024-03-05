using Azure.Messaging.ServiceBus;

namespace ServiceBusListener.Workers;

public class RndHostedService : IHostedService
{
    private readonly ILogger<RndHostedService> _logger;
    private readonly ServiceBusProcessor _processor;
    private readonly RndProcessor _rndProcessor;

    public RndHostedService(
        ILogger<RndHostedService> logger,
        ServiceBusClient serviceBusClient,
        RndProcessor rndProcessor
    )
    {
        _logger = logger;
        _rndProcessor = rndProcessor;
        _processor = serviceBusClient.CreateProcessor("sbt-rnd", "poc-subscription");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _processor.ProcessMessageAsync += _rndProcessor.ProcessorOnProcessMessageAsync;
        _processor.ProcessErrorAsync += _rndProcessor.ProcessorOnProcessErrorAsync;

        _logger.LogInformation("Starting processing Service Bus Message");
        await _processor.StartProcessingAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _processor.StopProcessingAsync(cancellationToken);
    }
}
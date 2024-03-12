using ServiceBusListener.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.ConfigureConfiguration(builder.Configuration);
builder.Services.ConfigureInfrastructure();

var host = builder.Build();

await host.RunAsync();
using Infrastructure.Context;
using IoC;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using Shared;
using WorkerService.ContatoCreateEventConsumer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.ConfigureDependencyInjection();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<Consumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetSection("RabbitMQ")["Host"], "/", h =>
        {
            h.Username(builder.Configuration.GetSection("RabbitMQ")["User"] ?? string.Empty);
            h.Password(builder.Configuration.GetSection("RabbitMQ")["Password"] ?? string.Empty);
        });

        cfg.ReceiveEndpoint(QueueNames.ContatoCreateQueue, e =>
        {
            e.ConfigureConsumer<Consumer>(context);
        });
    });
});


builder.Services.AddOpenTelemetry().WithMetrics(builder =>
{
    builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("your-service-name"));

    builder.AddRuntimeInstrumentation()
           .AddProcessInstrumentation();

    builder.AddPrometheusHttpListener(options =>
    {
        options.UriPrefixes = new[] { "http://worker:9464/" };
    });

});


var host = builder.Build();
host.Run();

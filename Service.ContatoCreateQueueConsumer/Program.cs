using Infra.Data.Context;
using IoC;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using Service.ContatoCreateQueueConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<Service.ContatoCreateQueueConsumer.Service>();

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.ConfigureDependencyInjection();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ContatoCreateQueueConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetSection("RabbitMQ")["Host"], "/", h =>
        {
            h.Username(builder.Configuration.GetSection("RabbitMQ")["User"] ?? string.Empty);
            h.Password(builder.Configuration.GetSection("RabbitMQ")["Password"] ?? string.Empty);
        });

        cfg.ReceiveEndpoint(ContatoCreateQueueConsumer.QueueName, e =>
        {
            e.ConfigureConsumer<ContatoCreateQueueConsumer>(context);
        });
    });
});

builder.Services.AddOpenTelemetry().WithMetrics(builder =>
{
    builder.AddAspNetCoreInstrumentation()
           .AddHttpClientInstrumentation()
           .AddRuntimeInstrumentation()
           .AddProcessInstrumentation()
           .AddPrometheusExporter();
});

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.Run();
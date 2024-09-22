using Infra.Data.Context;
using IoC;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Service.ContatoCreateQueueConsumer;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<Service.ContatoCreateQueueConsumer.Service>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.ConfigureDependencyInjection();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<QueueConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetSection("RabbitMQ")["Host"], "/", h =>
        {
            h.Username(builder.Configuration.GetSection("RabbitMQ")["User"] ?? string.Empty);
            h.Password(builder.Configuration.GetSection("RabbitMQ")["Password"] ?? string.Empty);
        });

        cfg.ReceiveEndpoint(QueueNames.ContatoCreateQueue, e =>
        {
            e.ConfigureConsumer<QueueConsumer>(context);
        });
    });
});

var app = builder.Build();
app.Run();
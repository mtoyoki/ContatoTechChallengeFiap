using Application.Commands.Contato.Queue;
using Application.Commands.Contato.Repository;
using Application.Queries.Contato;
using Core.Commands;
using Core.Queues;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Events.Contato;
using Domain.Repositories;
using FluentValidation;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Infra.QueuePublisher.Contato;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            //Data
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<IEventMessageRepository, EventMessageRepository>();

            //Command Validators
            services.AddScoped<IValidator<ContatoCreateCommand>, ContatoCreateCommandValidator>();
            services.AddScoped<IValidator<ContatoUpdateCommand>, ContatoUpdateCommandValidator>();
            services.AddScoped<IValidator<ContatoDeleteCommand>, ContatoDeleteCommandValidator>();

            //Queries
            services.AddScoped<IContatoQueriesHandler, ContatoQueriesHandlerHandler>();

            //Command Handlers

            //Fase 2: Grava diretamente no repositório
            //services.AddScoped<ICommandHandler<ContatoCreateCommand>, ContatoCreateInRepositoryCommandHandler>();
            //services.AddScoped<ICommandHandler<ContatoUpdateCommand>, ContatoUpdateInRepositoryCommandHandler>();
            //services.AddScoped<ICommandHandler<ContatoDeleteCommand>, ContatoDeleteInRepositoryCommandHandler>();

            //Fase 3: Grava na fila do RabbitMq
            services.AddScoped<ICommandHandler<ContatoCreateCommand>, ContatoCreateInQueueCommandHandler>();
            services.AddScoped<ICommandHandler<ContatoUpdateCommand>, ContatoUpdateInQueueCommandHandler>();
            services.AddScoped<ICommandHandler<ContatoDeleteCommand>, ContatoDeleteInQueueCommandHandler>();
            
            //Queue Publishers
            services.AddScoped<IQueue<ContatoCreateEventMsg>, ContatoCreateQueuePublisher>();
            services.AddScoped<IQueue<ContatoUpdateEventMsg>, ContatoUpdateQueuePublisher>();
            services.AddScoped<IQueue<ContatoDeleteEventMsg>, ContatoDeleteQueuePublisher>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }
    }
}

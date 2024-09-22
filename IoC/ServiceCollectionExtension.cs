using Application.Handlers.Contato.Db;
using Application.Handlers.Contato.Queue;
using Core.Commands;
using Core.Queues;
using Core.Validators;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Entities;
using Domain.Entities.Validators;
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

            //Entity Validators
            services.AddScoped<IEntityValidator<Contato>, ContatoEntityValidator>();

            //Command Handlers
            services.AddScoped<ICommandHandler<ContatoCreateCommand>, ContatoCreateInQueueCommandHandler>();
            services.AddScoped<ICommandHandler<ContatoUpdateCommand>, ContatoUpdateCommandHandler>();
            services.AddScoped<ICommandHandler<ContatoDeleteCommand>, ContatoDeleteCommandHandler>();

            //Queries
            services.AddScoped<IContatoQueriesHandler, ContatoQueriesHandlerHandler>();

            //Queue Publishers
            services.AddScoped<IQueue<ContatoCreateEventMsg>, ContatoCreateQueuePublisher>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }
    }
}

using Application.Contato;
using Core.Commands;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using FluentValidation;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyInjectionExtension
    {
        public static void Register(this IServiceCollection services)
        {
            //Data
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();

            //Validators
            services.AddScoped<IValidator<CreateContatoCommand>, CreateContatoCommandValidator>();
            services.AddScoped<IValidator<UpdateContatoCommand>, UpdateContatoCommandValidator>();
            services.AddScoped<IValidator<DeleteContatoCommand>, DeleteContatoCommandValidator>();

            //Command handler
            services.AddScoped<ICommandHandler<CreateContatoCommand>, CreateContatoCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateContatoCommand>, UpdateContatoCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteContatoCommand>, DeleteContatoCommandHandler>();

            //Queries
            services.AddScoped<IContatoQueries, ContatoQueries>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }
    }
}

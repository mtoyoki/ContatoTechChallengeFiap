using Application.AutoMapper;
using Core.Commands;
using Core.Extensions;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.Contato.Repository
{
    public class ContatoCreateInRepositoryCommandHandler(IValidator<ContatoCreateCommand> validator, IContatoRepository repository) : ICommandHandler<ContatoCreateCommand>
    {
        public CommandResult Handle(ContatoCreateCommand command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                repository.Insert(contato);

                return CommandResultFactory.CreateSuccessResult(contato.Id.ToString());
            }

            return CommandResultFactory.CreateErrorResult(validationResult.ToErrorList());
        }
    }
}
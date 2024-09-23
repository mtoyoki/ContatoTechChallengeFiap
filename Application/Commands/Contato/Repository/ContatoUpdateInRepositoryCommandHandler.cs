using Application.AutoMapper;
using Core.Commands;
using Core.Extensions;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.Contato.Repository
{
    public class ContatoUpdateInRepositoryCommandHandler(IValidator<ContatoUpdateCommand> validator, IContatoRepository repository) : ICommandHandler<ContatoUpdateCommand>
    {
        public CommandResult Handle(ContatoUpdateCommand command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                repository.Update(contato);

                return CommandResultFactory.CreateSuccessResult(contato.Id.ToString());
            }

            return CommandResultFactory.CreateErrorResult(validationResult.ToErrorList());
        }
    }
}
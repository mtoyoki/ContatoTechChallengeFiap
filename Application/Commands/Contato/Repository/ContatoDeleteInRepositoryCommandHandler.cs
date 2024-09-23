using Core.Commands;
using Core.Extensions;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.Contato.Repository
{
    public class ContatoDeleteInRepositoryCommandHandler(IValidator<ContatoDeleteCommand> validator, IContatoRepository repository) : ICommandHandler<ContatoDeleteCommand>
    {
        public CommandResult Handle(ContatoDeleteCommand command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
            {
                repository.Delete(command.Id);

                return CommandResultFactory.CreateSuccessResult(command.Id.ToString());
            }

            return CommandResultFactory.CreateErrorResult(validationResult.ToErrorList());
        }
    }
}

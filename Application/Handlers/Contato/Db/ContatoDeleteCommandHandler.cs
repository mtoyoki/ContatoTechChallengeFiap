using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Application.Handlers.Contato.Db
{
    public class ContatoDeleteCommandHandler : CommandHandlerBase, ICommandHandler<ContatoDeleteCommand>
    {
        private readonly IValidator<ContatoDeleteCommand> _validator;
        private readonly IContatoRepository _contatoRepository;

        public ContatoDeleteCommandHandler(IValidator<ContatoDeleteCommand> deleteContatoCommandValidator,
                                           IContatoRepository contatoRepository)
        {
            _validator = deleteContatoCommandValidator;
            _contatoRepository = contatoRepository;
        }

        public Result Handle(ContatoDeleteCommand command)
        {
            var validationResult = _validator.Validate(command);
            //Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (validationResult.IsValid)
            {
                _contatoRepository.Delete(command.Id);
            }

            return Result();
        }
    }
}

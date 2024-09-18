using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

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
            var validationResult = Validate(command, _validator);

            if (validationResult.IsValid)
            {
                _contatoRepository.Delete(command.Id);
            }

            return Result();
        }
    }
}

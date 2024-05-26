using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Contato
{
    public class DeleteContatoCommandHandler : CommandHandlerBase, ICommandHandler<DeleteContatoCommand>
    {
        private readonly IValidator<DeleteContatoCommand> _validator;
        private readonly IContatoRepository _contatoRepository;

        public DeleteContatoCommandHandler(IValidator<DeleteContatoCommand> deleteContatoCommandValidator,
                                           IContatoRepository contatoRepository)
        {
            _validator = deleteContatoCommandValidator;
            _contatoRepository = contatoRepository;
        }

        public Result Handle(DeleteContatoCommand command)
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

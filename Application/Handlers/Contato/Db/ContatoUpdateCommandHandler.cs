using Application.AutoMapper;
using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Handlers.Contato.Db
{
    public class ContatoUpdateCommandHandler : CommandHandlerBase, ICommandHandler<ContatoUpdateCommand>
    {
        private readonly IValidator<ContatoUpdateCommand> _updateContatoCommandValidator;
        private readonly IContatoRepository _contatoRepository;

        public ContatoUpdateCommandHandler(IValidator<ContatoUpdateCommand> updateContatoCommandValidator,
                                           IContatoRepository contatoRepository)
        {
            _updateContatoCommandValidator = updateContatoCommandValidator;
            _contatoRepository = contatoRepository;
        }

        public Result Handle(ContatoUpdateCommand command)
        {
            var validationResult = Validate(command, _updateContatoCommandValidator);

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                _contatoRepository.Update(contato);
            }

            return Result();
        }
    }
}

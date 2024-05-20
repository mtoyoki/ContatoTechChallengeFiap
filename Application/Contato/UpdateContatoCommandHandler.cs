using Application.AutoMapper;
using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Contato
{
    public class UpdateContatoCommandHandler : CommandHandlerBase, ICommandHandler<UpdateContatoCommand>
    {
        private readonly IValidator<UpdateContatoCommand> _updateContatoCommandValidator;
        private readonly IContatoRepository _contatoRepository;

        public UpdateContatoCommandHandler(IValidator<UpdateContatoCommand> updateContatoCommandValidator, IContatoRepository contatoRepository)
        {
            _updateContatoCommandValidator = updateContatoCommandValidator;
            _contatoRepository = contatoRepository;
        }

        public Result Handle(UpdateContatoCommand command)
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

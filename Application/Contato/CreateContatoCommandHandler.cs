using Application.AutoMapper;
using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Contato
{
    public class CreateContatoCommandHandler : CommandHandlerBase, ICommandHandler<CreateContatoCommand>
    {
        private readonly IValidator<CreateContatoCommand> _validator;
        private readonly IContatoRepository _contatoRepository;

        public CreateContatoCommandHandler(IValidator<CreateContatoCommand> createContatoCommandValidator,
                                           IContatoRepository contatoRepository)
        {
            _validator = createContatoCommandValidator;
            _contatoRepository = contatoRepository;
        }

        public Result Handle(CreateContatoCommand command)
        {
            var validationResult = Validate(command, _validator);

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                _contatoRepository.Insert(contato);
            }

            return Result();
        }
    }
}
using Application.AutoMapper;
using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Application.Handlers.Contato.Db
{
    public class ContatoCreateInDbCommandHandler : CommandHandlerBase, ICommandHandler<ContatoCreateCommand>
    {
        private readonly IValidator<ContatoCreateCommand> _validator;
        private readonly IContatoRepository _repository;

        public ContatoCreateInDbCommandHandler(IValidator<ContatoCreateCommand> validator, IContatoRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public Result Handle(ContatoCreateCommand command)
        {
            var validationResult = Validate(command, _validator);

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                _repository.Insert(contato);
            }

            return Result();
        }
    }
}
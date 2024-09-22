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
            var id = 0;
            var validationResult = _validator.Validate(command);
            //Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                _repository.Insert(contato);
                id = contato.Id;
            }

            return Result(id.ToString());
        }
    }
}
using Application.AutoMapper;
using Core.Commands;
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Application.Handlers.Contato.Db
{
    public class ContatoUpdateCommandHandler : CommandHandlerBase, ICommandHandler<ContatoUpdateCommand>
    {
        private readonly IValidator<ContatoUpdateCommand> _validator;
        private readonly IContatoRepository _contatoRepository;

        public ContatoUpdateCommandHandler(IValidator<ContatoUpdateCommand> validator,
                                           IContatoRepository contatoRepository)
        {
            _validator = validator;
            _contatoRepository = contatoRepository;
        }

        public Result Handle(ContatoUpdateCommand command)
        {
            var validationResult = _validator.Validate(command);
            //Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (validationResult.IsValid)
            {
                var contato = ContatoMapper.CommandToEntity(command);
                _contatoRepository.Update(contato);
            }

            return Result();
        }
    }
}

using Domain.Repositories;
using FluentValidation;

namespace Domain.Commands.Contato.Validators
{
    public class UpdateContatoCommandValidator : ContatoCommandValidatorBase<UpdateContatoCommand>
    {
        private readonly IContatoRepository _contatoRepository;

        public UpdateContatoCommandValidator(IContatoRepository contatoRepository, IRegiaoRepository regiaoRepository) : base(regiaoRepository)
        {
            _contatoRepository = contatoRepository;

            ValidateId();
            ValidateExists();
        }

        private void ValidateId()
        {
            RuleFor(command => command.Id)
                .Must(id => !id.Equals(0))
                .WithSeverity(Severity.Error)
                .WithMessage("Preenchimento do Id é obrigatório");
        }

        private void ValidateExists()
        {
            RuleFor(command => command.Id)
                .Must(id => _contatoRepository.GetById(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("Não foi possível encontrar o Contato");
        }
    }
}
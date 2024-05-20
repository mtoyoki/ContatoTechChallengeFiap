using Domain.Repositories;
using FluentValidation;

namespace Domain.Commands.Contato.Validators
{
    public class UpdateContatoCommandValidator : ContatoCommandValidatorBase<UpdateContatoCommand>
    {
        public UpdateContatoCommandValidator(IRegiaoRepository regiaoRepository) : base(regiaoRepository)
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(command => command.Id)
                .Must(id => !id.Equals(0))
                .WithSeverity(Severity.Error)
                .WithMessage("Preenchimento do ID do Contato é obrigatório");
        }
    }
}
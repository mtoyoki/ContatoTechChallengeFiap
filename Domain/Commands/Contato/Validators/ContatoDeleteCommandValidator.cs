using Domain.Repositories;
using FluentValidation;

namespace Domain.Commands.Contato.Validators
{
    public class ContatoDeleteCommandValidator : AbstractValidator<ContatoDeleteCommand>
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoDeleteCommandValidator(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;

            ValidateExists();
        }

        private void ValidateExists()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Preenchimento do Id é obrigatório");

            RuleFor(command => command.Id)
                .Must(id => _contatoRepository.GetById(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("Não foi possível encontrar o Contato");
        }
    }
}
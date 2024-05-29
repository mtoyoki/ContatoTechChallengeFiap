using Domain.Repositories;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Domain.Commands.Contato.Validators
{
    public abstract class ContatoCommandValidatorBase<T> : AbstractValidator<T> where T : ContatoCommandBase
    {

        private readonly IRegiaoRepository _regiaoRepository;

        protected ContatoCommandValidatorBase(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
            ValidateNome();
            ValidateEmail();
            ValidateTelefone();
            ValidateRegionId();
        }

        private void ValidateNome()
        {
            RuleFor(command => command.Nome)
                .NotEmpty()
                .WithMessage("Preenchimento do Nome é obrigatório");

            RuleFor(command => command.Nome)
                .Length(3, 100)
                .WithMessage("Nome inválido");
        }

        private void ValidateEmail()
        {
            Regex EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Preenchimento do E-mail é obrigatório");

            RuleFor(command => command.Email)
                .Must(email => EmailRegex.IsMatch(email))                
                .WithMessage("E-mail inválido");

        }

        private void ValidateTelefone()
        {
            Regex PhoneRegex = new Regex(@"^\(?\d{2}\)? ?9?\d{4}-?\d{4}$", RegexOptions.Compiled);

            RuleFor(command => command.Telefone)
                .NotEmpty()
                .WithMessage("Preenchimento do Telefone é obrigatório");

            RuleFor(command => command.Telefone)
                .Must(telefone => PhoneRegex.IsMatch(telefone))
                .WithMessage("Telefone inválido")
                .When(c => !string.IsNullOrEmpty(c.Telefone));
        }

        private void ValidateRegionId()
        {

            RuleFor(command => command.RegiaoId)
                .NotEmpty()
                .WithMessage("Preenchimento do DDD é obrigatório");

            RuleFor(command => command.RegiaoId)
                .Must(id => _regiaoRepository.GetById(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("Número do DDD inválido");
        }

    }
}

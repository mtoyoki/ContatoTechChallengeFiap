using Domain.Repositories;
using FluentValidation;
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
            ValidateRegiaoId();
        }

        protected void ValidateNome()
        {
            RuleFor(contato => contato.Nome)
                .NotEmpty()
                .WithMessage("Preenchimento do Nome é obrigatório");

            RuleFor(contato => contato.Nome)
                .Length(3, 100)
                .WithMessage("Nome inválido");
        }

        protected void ValidateEmail()
        {
            Regex EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            RuleFor(contato => contato.Email)
                .NotEmpty()
                .WithMessage("Preenchimento do E-mail é obrigatório");

            RuleFor(contato => contato.Email)
                .Must(email => EmailRegex.IsMatch(email))
                .WithMessage("E-mail inválido");
        }

        protected void ValidateTelefone()
        {
            Regex PhoneRegex = new Regex(@"^\(?\d{2}\)? ?9?\d{4}-?\d{4}$", RegexOptions.Compiled);

            RuleFor(contato => contato.Telefone)
                .NotEmpty()
                .WithMessage("Preenchimento do Telefone é obrigatório");

            RuleFor(contato => contato.Telefone)
                .Must(telefone => PhoneRegex.IsMatch(telefone))
                .WithMessage("Telefone inválido")
                .When(c => !string.IsNullOrEmpty(c.Telefone));
        }

        protected void ValidateRegiaoId()
        {
            RuleFor(contato => contato.RegiaoId)
                .NotEmpty()
                .WithMessage("Preenchimento do RegiaoId é obrigatório");

            RuleFor(command => command.RegiaoId)
                .Must(id => _regiaoRepository.GetById(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("Número do DDD inválido");
        }
    }
}
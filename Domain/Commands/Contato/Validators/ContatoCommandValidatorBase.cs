using Domain.Repositories;
using FluentValidation;

namespace Domain.Commands.Contato.Validators
{
    public abstract class ContatoCommandValidatorBase<T>: AbstractValidator<T> where T: ContatoCommandBase
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
                .Must(nome=> !string.IsNullOrEmpty(nome))
                .WithMessage("Preenchimento do Nome é obrigatório");

            RuleFor(command => command.Nome)
                .Length(3, 100)
                .WithMessage("Nome inválido");
        }

        private void ValidateEmail()
        {
            RuleFor(command => command.Email)                
                .Must(email => !string.IsNullOrEmpty(email))
                .WithMessage("Preenchimento do E-mail é obrigatório");

            RuleFor(command => command.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");
        }

        private void ValidateTelefone()
        {
            RuleFor(command => command.Telefone)
                .Must(telefone => !string.IsNullOrEmpty(telefone))
                .WithMessage("Preenchimento do Telefone é obrigatório");

            RuleFor(command => command.Telefone)
                .Length(10,11)
                .WithMessage("Telefone inválido");
        }

        private void ValidateRegionId()
        {
            RuleFor(command => command.Telefone)
                .Length(2)
                .WithMessage("Número do DDD inválido");

            RuleFor(command => command.RegiaoId)
                .Must(id => _regiaoRepository.GetById(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("Número do DDD inexistente");
        }

    }
}

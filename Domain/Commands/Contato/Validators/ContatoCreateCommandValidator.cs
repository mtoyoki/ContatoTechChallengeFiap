using Domain.Commands.Contato;
using Domain.Entities.Interfaces;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Commands.Contato.Validators
{
    public class ContatoCreateCommandValidator : AbstractValidator<ContatoCreateCommand>
    {
        public new ValidationResult Validate(ContatoCreateCommand instance)
        {
            
            throw new NotImplementedException();
        }
    }
}
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Commands.Contato.Validators
{

    public class ContatoUpdateCommandValidator : AbstractValidator<ContatoUpdateCommand>
    {
        public new ValidationResult Validate(ContatoUpdateCommand instance)
        {
            throw new NotImplementedException();
        }
    }
}
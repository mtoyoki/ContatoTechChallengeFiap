using Core.Validators;
using Domain.Validators;
using FluentValidation.Results;

namespace Domain.Entities.Validators
{
    public class ContatoEntityValidator : ContatoValidatorBase<Contato>, IEntityValidator<Contato>

    {
        public ValidationResult ValidateInsert(Contato entity)
        {
            return new ValidationResult();
        }
    }
}

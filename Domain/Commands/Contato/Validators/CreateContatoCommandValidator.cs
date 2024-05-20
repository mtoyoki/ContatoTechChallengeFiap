using Domain.Repositories;
using FluentValidation;

namespace Domain.Commands.Contato.Validators
{
    public class CreateContatoCommandValidator : ContatoCommandValidatorBase<CreateContatoCommand>
    {
        public CreateContatoCommandValidator(IRegiaoRepository regiaoRepository) : base(regiaoRepository)
        {
        }
    }
}
using Domain.Repositories;

namespace Domain.Commands.Contato.Validators
{
    public class ContatoCreateCommandValidator : ContatoCommandValidatorBase<ContatoCreateCommand>
    {

        public ContatoCreateCommandValidator(IRegiaoRepository regiaoRepository) : base(regiaoRepository)
        {
        }
    }
}
using Domain.Commands.Contato;
using Domain.Repositories;
using FluentValidation;

namespace Domain.Commands.Contato.Validators
{
    public class ContatoCreateCommandValidator : ContatoCommandValidatorBase<ContatoCreateCommand>
    {
    }
}
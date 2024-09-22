using Domain.Commands.Contato;
using Domain.Repositories;
using Domain.Validators;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Contato.Validators
{
    public abstract class ContatoCommandValidatorBase<T> : ContatoValidatorBase<T> where T : ContatoCommandBase
    {
        protected ContatoCommandValidatorBase()
        {
            ValidateNome();
            ValidateEmail();
            ValidateTelefone();
            ValidateRegiaoId();
        }
    }
}
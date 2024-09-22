using FluentValidation.Results;

namespace Core.Validators
{
    public interface IEntityValidator<in T>
    {
        ValidationResult ValidateInsert(T entity);
        //ValidationResult ValidateUpdate(T entity);
        //ValidationResult ValidateDelete(int id);
    }
}
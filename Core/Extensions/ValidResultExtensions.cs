using FluentValidation.Results;

namespace Core.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<string> ToErrorList(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(error => error.ErrorMessage).ToList();
        }
    }
}
using FluentValidation;
using FluentValidation.Results;

namespace Core.Commands
{
    public abstract class CommandHandlerBase
    {
        protected IEnumerable<string> Notifications;

        protected ValidationResult Validate<T, TValidator>(
            T command,
            TValidator validator)
            where T : CommandBase
            where TValidator : IValidator<T>
        {
            var validationResult = validator.Validate(command);
            Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            return validationResult;
        }

        public Result Result(string message="")
        {
            var success = !Notifications.Any();

            return new Result(success, message, Notifications);
        }
    }
}

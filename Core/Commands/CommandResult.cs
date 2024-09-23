namespace Core.Commands
{
    public class CommandResult(bool success, string message, IEnumerable<string> errors)
    {
        public readonly bool Success = success;

        public readonly string Message = message;

        public readonly IEnumerable<string> Errors = errors;
    }
}

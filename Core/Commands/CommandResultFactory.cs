namespace Core.Commands
{
    public class CommandResultFactory
    {
        public static CommandResult CreateSuccessResult(string message)
        {
            return new CommandResult(true, message, null);
        }

        public static CommandResult CreateErrorResult(IEnumerable<string> errors)
        {
            return new CommandResult(false, "", errors);
        }
    }
}

namespace Core.Commands
{
    public class Result
    {
        public readonly bool Success;
        
        public readonly string Message;

        public readonly IEnumerable<string> Errors;


        public Result(bool success, string message, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }
    }
}
